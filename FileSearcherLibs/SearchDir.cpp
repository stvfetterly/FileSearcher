
#include <boost/algorithm/string/case_conv.hpp>


#include <fstream>

/*
 * Search Directory:
 * Recursively searches through all files in a given directory.
 */
#include <string>
#include <iostream>
#include <vector>
#include "FileMatch.h"
#include "SearchDir.h"
#include "boost/filesystem.hpp"                     //used for creating path objects and directory iterators
#include "boost/algorithm/string/case_conv.hpp"     //used to convert strings to uppercase
#include "boost/filesystem/fstream.hpp"             //used for fstream operations
#include "boost/algorithm/string/find.hpp"          //used for finding text in strings



using namespace std;
namespace bf = boost::filesystem;
namespace ba = boost::algorithm;

SearchDir::SearchDir()
{
    _startPath = "/";                               //Start path in root dir. by default
    _searchString = "";
    _searchAllFiles = true;                        //Default is to search all files
    _searchPath = new bf::path(_startPath);         //Sets _searchPath to point at the path object
    _relevanceStyle = SD_REL_BOTH;
}
SearchDir::~SearchDir()
{
    delete _searchPath;
}
void SearchDir::SetStartPath(string path)
{
    bf::path newPath( path );
    if (bf::exists(newPath))
    {
        _startPath = path;
        *_searchPath = _startPath;
    }
    else //throw exception
    {
        throw ER_INVALID_PATH;
    }
}
void SearchDir::SetRelevanceStyle(int relevanceStyle)
{
    _relevanceStyle = relevanceStyle;
}


//Break up string by ' ' characters and save all words in a vector
void SearchDir::SetSearchString(string input)
{
    _searchString = input;
    vector<string> srchStrPrtsTmp = TokenizeInputString(" ", _searchString);

    //converts all tokenized strings in vector to uppercase and removes duplicates
    for (int i = 0; i < srchStrPrtsTmp.size(); i++)
    {
        ba::to_upper( srchStrPrtsTmp.at(i) );                            //set each string to all uppercase letters (used for searching later)
        if (!CheckForDuplicate( srchStrPrtsTmp[i], _searchStringParts ) )       //if no duplicate file name is found, add it to the list of names
        {
            _searchStringParts.push_back( srchStrPrtsTmp.at(i) );
        }
    }
}

//Break up string by ' ' characters and save all words in a vector
vector<string> SearchDir::TokenizeInputString(string delimiters, const string &input)
{
    vector<string> output;

    //If there are delimeters at the begining of the search string, ignore them
    string::size_type startWord = input.find_first_not_of(delimiters, 0);
    string::size_type endWord = input.find_first_of(delimiters, startWord);

    //while the end or start of a word is found in the input string
    while (string::npos != endWord || string::npos != startWord)
    {
        // Found a word, add it to the vector.
        output.push_back(input.substr(startWord, endWord - startWord));
        // Skip delimiters, and finds the first character after the last word that starts a new word
        startWord = input.find_first_not_of(delimiters, endWord);
        // Find next delimeter which ends the current word that we're looking at
        endWord = input.find_first_of(delimiters, startWord);
    }
    return output;
}

void SearchDir::SetFileType(vector<string> fileNames)
{
    _fileNames = fileNames;
}

//This function takes in a value and checks the _fileNames vector of strings for a duplicate.  If one is found, it returns true
bool SearchDir::CheckForDuplicate(const string &value, const vector<string> &searchVector)
{
    for (int i = 0; i < searchVector.size(); i++)
    {
        if (searchVector[i] == value)
        {
            return true;
        }
    }
    return false;
}

void SearchDir::StartSearch()
{
    Search(*_searchPath);
}

void SearchDir::SearchAllFiles(bool search)
{
    _searchAllFiles = search;
}

bool  SearchDir::CheckValidExtension(const string &fileName)
{
    bool retVal = false;
    string extension = bf::extension(fileName);

    if (_searchAllFiles) //if we search all files, then any extension is valid
    {
        retVal = true;
    }
    else
    {
        for (int i = 0; i < _fileNames.size();i++)
        {
            if (extension == _fileNames[i])  //if the extension is what we're searching for then continue
            {
                retVal = true;
                i = _fileNames.size();      //this code breaks out of the for...loop if a file extension is found
            }
        }
    }
    return retVal;
}

 //Takes in a file name, if the file name contains the case sensitive search string, returns true
bool SearchDir::SearchFileNamesCS(const string &fileName)
{
    string::size_type loc = fileName.find( _searchString, 0 );
    if( loc != string::npos ) //if the string is found in the name, then a match is created
    {
        return true;
    }
    return false;
}
 //Takes in a file name, if the file name contains the case insensitive search string, returns true
bool SearchDir::SearchFileNames(string fileName)
{
    string searchString = _searchString;    //creates a copy of searchstring that we can cast to uppercase
    ba::to_upper(fileName);  //convert filename to uppercase characaters
    ba::to_upper(searchString);
    string::size_type loc = fileName.find( searchString, 0 );
    if( loc != string::npos ) //if the string is found in the name, then a match is created
    {
        return true;
    }
    return false;
}

int SearchDir::SearchFileForPartialMatch(string fileName)
{
    int numMatches = 0;
    string::size_type loc = string::npos;//fileName.find( searchString, 0 );
    ba::to_upper(fileName);  //convert filename to uppercase characaters

    for (int i = 0; i < _searchStringParts.size(); i++) //check all words that are being searched for
    {
        loc = fileName.find( _searchStringParts.at(i) );//find the location of the first occurance of the current word we're looking at
        if (loc != string::npos)                //if the word is found in the string, record it
        {
            numMatches++;
        }
    }
    return numMatches;
}

 //Searches the text in a file for the full search string, returns true if it is found
void SearchDir::SearchTextNamesCS( const string &fileAndPath, bool &CSTextFound, bool &TextFound, int &partialMatchText)
{
    CSTextFound = false;
    TextFound = false;
    bool stopLoop = false;
    string searchStringUpper = _searchString;
    ba::to_upper(searchStringUpper);

    //itemFound is used to keep multiple matches of the same word in the text file from counting as multiple hits
    bool itemFound[_searchStringParts.size()];
    for (int i = 0; i<_searchStringParts.size(); i++)
    {
        itemFound[i] = false;
    }

    char dataFromFile[2000];
    bf::fstream inputFile;
    //inputFile.open(fileAndPath, );
    inputFile.open(fileAndPath, ios::in);

    if (inputFile.is_open())
    {
        while ( inputFile.good() && !stopLoop)                        //checks through the file unless reach EOF, or something bad happens
        {
            inputFile.getline(dataFromFile, 2000);     //gets 2000 characters from the file being examined
            string dataFromFileStr = dataFromFile;
            string::size_type loc = dataFromFileStr.find(_searchString, 0);
            if (loc != string::npos) //checks if the CS text being searched for is found.
            {
                CSTextFound = true;
                TextFound = true;
                partialMatchText = _searchStringParts.size();
                stopLoop = true;
            }
            else
            {
                ba::to_upper(dataFromFileStr);
                loc = dataFromFileStr.find(searchStringUpper, 0);
                if (loc != string::npos)  //checks if the non-CS text being searched for is found.
                {
                    TextFound = true;
                    partialMatchText = _searchStringParts.size();
                    stopLoop = true;
                }
                else
                {
                    for (int i = 0; i < _searchStringParts.size(); i++) //Loop through all partial matches
                    {
                        loc = dataFromFileStr.find(_searchStringParts[i], 0);
                        if ( loc != string::npos &&
                             itemFound[i] == false)                                 //Test file text for partial matches, ensures multiple partial matches are not also counted
                        {
                            partialMatchText++;
                            itemFound[i] = true;                    //indicate that this item has been matched already
                        }
                    }
                }
            }
        }
        inputFile.close(); //closes the file being read from
    }
}

//This function recursively searches the given directory for files.
void SearchDir::Search(const bf::path &dir_path)
{
    bf::directory_iterator end_itr;
    
    //loops through a directory and outputs files and folders
    for ( bf::directory_iterator itr( dir_path ); itr != end_itr; ++itr )
    {
        //Recursively search through all directories
        if (bf::is_directory(itr->status()))
        {
            Search(itr->path());
        }
        //File found, test for match
        else
        {
            TestFileMatch(itr);
        }
    }
}

//Find file, test file name, test file content
void SearchDir::TestFileMatch(const bf::directory_iterator &itr)
{
    bool validExtension = CheckValidExtension(itr->leaf());
    bool fileMatchCS = false;
    bool fileMatch = false;
    bool textMatchCS = false;
    bool textMatch = false;
    int partialMatchTitle = 0;
    int partialMatchText = 0;

    //Search the text of a file for search strings only if we are supposed to and the file has a good extension
    if ( (_relevanceStyle == SD_REL_TITLE || _relevanceStyle == SD_REL_BOTH) && (validExtension) )
    {
        if (validExtension) //if the file has an invalid extension, then there's no need to search the name
        {
            fileMatchCS = SearchFileNamesCS( itr->leaf() );

            if (fileMatchCS)    //if we have a case sensitive match, we also have a case insensitive file match
            {
                fileMatch = true;
            }
            else                //check case insensitive match if we don't have a case sensitive match
            {
                fileMatch = SearchFileNames( itr->leaf() );
            }

            if (fileMatch)  //if we have a full search string match, then we know that all words in the search string have been found
            {
                partialMatchTitle = _searchStringParts.size();
            }
            else        //if we don't have a full string match, search for a partial string match
            {
                partialMatchTitle = SearchFileForPartialMatch( itr->leaf() );
            }
        }
    }
    //Search the text of a file for search strings only if we are supposed to and the file has a good extension
    if ( (_relevanceStyle == SD_REL_TEXT || _relevanceStyle == SD_REL_BOTH) && (validExtension) )
    {
        //Check in the files for a string match
        SearchTextNamesCS(itr->string(),  textMatchCS, textMatch, partialMatchText);
    }
    
    //Test file name for match
    if ( fileMatchCS || fileMatch || partialMatchTitle ||
         textMatchCS || textMatch || partialMatchText)
    {
        //adds another fileMatch object to the vector
        FileMatch newFileMatch(itr->leaf(), TrimFileFromPath(itr->string(), itr->leaf()), itr->string(),
                                fileMatchCS, fileMatch, partialMatchTitle,
                                textMatchCS, textMatch, partialMatchText,
                                _searchStringParts.size(), _relevanceStyle);
        _fileArray.push_back(newFileMatch);
    }
}

void SearchDir::DisplayAllFiles()
{
    for (int i = 0; i < _fileArray.size(); i++)
    {
        DisplayAt(i);
    }
}
void SearchDir::DisplayAt(int index)
{
    cout<<"File: "<< _fileArray[index].GetFileName() << "\t\t"
        <<"Relevance:" << _fileArray[index].GetRelevance() << endl;
}
int SearchDir::NumberOfFilesFound()
{
    return _fileArray.size();
}

string SearchDir::TrimFileFromPath(string file_path, const string &file_name)
{
    int i = file_path.find(file_name);    //finds the character that the file name starts at
    file_path.erase(i, file_name.size());   //deletes from the character that the file name starts at
    return file_path;
}