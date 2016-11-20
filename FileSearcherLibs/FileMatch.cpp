#include <string>
#include <iostream>         //needed for debugging purposes only
#include "FileMatch.h"
using namespace std;

FileMatch::FileMatch()
{
    _fileName = "";
    _filePath = "";
    _fullName = "";
    _relevance = 0.0;
    _wordsSearched = 0;

    _foundIn[FM_TITLE] = false;
    _foundInCS[FM_TITLE] = false;
    _partialMatch[FM_TITLE] = 0;

    _foundIn[FM_TEXT] = false;
    _foundInCS[FM_TEXT] = false;
    _partialMatch[FM_TEXT] = 0;
    _relevanceStyle = FM_REL_BOTH;
}
FileMatch::FileMatch(string name, string path, string fullName,
                    bool foundInTitle, bool foundInTitleCS, int partialMatchTitle,
                    bool foundInText,    bool foundInTextCS,int partialMatchText,
                    int wordsSearched, int relevanceStyle)
{
    _fileName = name;
    _filePath = path;
    _fullName = fullName;
    _wordsSearched = wordsSearched;

    _foundIn[FM_TITLE] = foundInTitle;
    _foundInCS[FM_TITLE] = foundInTitleCS;
    _partialMatch[FM_TITLE] = partialMatchTitle;

    _foundIn[FM_TEXT] = foundInText;
    _foundInCS[FM_TEXT] = foundInTextCS;
    _partialMatch[FM_TEXT] = partialMatchText;
    _relevanceStyle = relevanceStyle;
    CalculateRelevance();   //must be run last as it needs the data from the constructor to do all calculations
}
FileMatch::~FileMatch()
{
}
void FileMatch::SetFileName(string name)
{
    _fileName = name;
}
void FileMatch::SetFilePath(string path)
{
    _filePath = path;
}
void FileMatch::CalculateRelevance()
{
    switch(_relevanceStyle)
    {
        case FM_REL_TEXT:   //only checks the text for hits
            _relevance = PercentMatch(FM_TEXT);
            break;
        case FM_REL_TITLE:   //only checks the file title
            _relevance = PercentMatch(FM_TITLE);
            break;
        case FM_REL_BOTH:   //averages between both types of hits that are found.  Text hits are considered twice as important.
            _relevance = (PercentMatch(FM_TITLE) + (PercentMatch(FM_TEXT)*2) ) /3;
            break;
    }
}

//This function calculates a percentage match for either a text or filename hit
float FileMatch::PercentMatch(const int &type)
{
    float output = 0.0;
    if (_foundInCS[type])    //exact string match, case sensitive
    {
        output += 10.0; //with no case sensitive hit, the closest match we can find is 100 - 10 or 90%
    }

    if (_foundIn[type]) //exact string match, case insensitive
    {
        output += 10.0; //with no full string hit (case insensitive), the closest match we can find is 100 - 10 - 10 (80%)
    }

    if (_wordsSearched > 0 && _partialMatch[type] > 0)  //partial word match
    {
        output += ((float)_partialMatch[type] / (float)_wordsSearched) * 80; //Partial word match, the closest match that we can find is 80%
    }
    return output;
}

float FileMatch::GetRelevance()
{
    return _relevance;
}
string FileMatch::GetFileName()
{
    return _fileName;
}
string FileMatch::GetFilePath()
{
    return _filePath;
}
string FileMatch::GetFullName()
{
    return _fullName;
}