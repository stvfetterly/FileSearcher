/* 
 * File:   SearchDir.h
 * Author: steven
 *
 * Created on November 17, 2008, 8:05 AM
 */

#ifndef _SEARCHDIR_H
#define	_SEARCHDIR_H
#include <string>
#include <vector>
#include "FileMatch.h"
#include "boost/filesystem.hpp"

using namespace std;
namespace bf = boost::filesystem;

//A listing of all errors that can be thrown by this class
enum ERROR_LIST
{
    ER_INVALID_PATH
};

const int SD_REL_TEXT = 0;
const int SD_REL_TITLE = 1;
const int SD_REL_BOTH = 2;

class SearchDir
{
public:
    SearchDir();                                //Constructor
    virtual ~SearchDir();                       //Destructor
    virtual void SetRelevanceStyle(int relevanceStyle);           //can select between relevance ranking by Text data = 0, File name = 1, or by using both.  Default is both = 2.
    virtual void StartSearch();                 //Searches for files, saves all matched files for later output
    virtual void SetStartPath(string path);     //Sets the path to start searching from
    virtual void SetSearchString(string input); //Sets the string being searched for
    virtual void SetFileType(vector<string> fileNames);     //sends a vector of strings contaiing all file type that are being searched for
    virtual void SearchAllFiles(bool search);   //controls if the search is limited by file type, or if all files are searchable
    virtual void DisplayAllFiles();             //displays all matched files
    virtual void DisplayAt(int index);          //displays a particular matched file
    virtual int NumberOfFilesFound();            //returns the number of files that have been found and matched the search
    
protected:
    int _relevanceStyle;            //changes the relevance algorithm to rank by filename matches, text in file matches, or both
    string _startPath;
    string _searchString;
    vector<string>_searchStringParts;                     //contains the original search string tokenized by spaces (" ")
    vector<string> _fileNames;
    bool _searchAllFiles;                                       //flag that indicates all file types are being searched if true
    vector<FileMatch> _fileArray;
    void Search(const bf::path &dir_path);                      //Iterates through all files, directories, subdirectories, adds FileMatch objects to _fileArray vector when found
    bool CheckForDuplicate(const string &value, const vector<string> &vector);//This function takes in a value and checks the input vector of strings for a duplicate.  If one is found, it returns true
    bool SearchFileNamesCS(const string &fileName);                    //if the input contains the case sensitive search string it returns true
    bool SearchFileNames(string fileName);                      //if the input contains the case insensitive search string it returns true
    int SearchFileForPartialMatch(string fileName);             //returns the number of words from the search string that were found
    void SearchTextNamesCS(const string &fileAndPath,  bool &CSTextFound, bool &TextFound, int &partialMatchText);//Searches the text in a file for the input string, returns true if it is found
    string TrimFileFromPath(string fullPath, const string &fileName);  //Takes in a path with file name, and filename, returns a string without the filename
    bool CheckValidExtension(const string &fileName);                  //Takes in a file name with extension and determines if it's one of the extensions to be searched
    vector<string> TokenizeInputString(string delimiters, const string &input);   //Break up string by ' ' characters and save all words in a vector that is then output
    void TestFileMatch(const bf::directory_iterator &itr);              //Tests for file match, adds the file to vector if a match is made
private:
    bf::path *_searchPath;
};

#endif	/* _SEARCHDIR_H */

