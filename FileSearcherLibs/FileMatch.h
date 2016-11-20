/* 
 * File:   FileMatch.h
 * Author: steven
 *
 * Created on November 18, 2008, 1:10 PM
 */

#ifndef _FILEMATCH_H
#define	_FILEMATCH_H
#include <string>
using namespace std;

const int FM_TITLE = 0;
const int FM_TEXT = 1;

const int FM_REL_TEXT = 0;
const int FM_REL_TITLE = 1;
const int FM_REL_BOTH = 2;

class FileMatch
{
public:
    FileMatch();                                        //constructor
    virtual ~FileMatch();                               //destructor
    FileMatch(string name, string path, string fullName,
                      bool foundInTitle, bool foundInTitleCS, int partialMatchTitle,
                      bool foundInText,    bool foundInTextCS,int partialMatchText,
                      int wordsSearched, int relevanceStyle);   //overload for constructor, allows entry of file name, path, and where the data was found
    virtual void SetFileName(string name);
    virtual void SetFilePath(string path);
    virtual string GetFileName();   
    virtual string GetFilePath();
    virtual string GetFullName();                       //returns the path and file name together
    virtual float GetRelevance();                       //returns the relevance of the file match
protected:
    string _fileName;
    string _filePath;
    string _fullName;
    float _relevance;
    bool _foundIn[2];               //case insensitive found in text
    bool _foundInCS[2];             //case sensitive found in text
    int _partialMatch[2];           //number of words partially matched in text and title
    int _wordsSearched;             //number of words to partially match
    int _relevanceStyle;            //changes the relevance algorithm to rank by filename matches, text in file matches, or both
    void CalculateRelevance();
    float PercentMatch(const int &type);   //This function calculates a percentage match for either a text or filename hit
};


#endif	/* _FILEMATCH_H */

