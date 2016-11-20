/* 
 * File:   FileSearcher.cpp
 * Author: steven
 *
 * Created on November 17, 2008, 7:55 AM
 */

#include <stdlib.h>
#include <iostream>
#include <vector>
#include "SearchDir.h"

using namespace std;
/*
 * 
 */
int main(int argc, char** argv) 
{
    vector<string> filesToSearch;
    string file1 = ".mk";
    string file2 = ".cpp";
    string file3 = ".txt";

    filesToSearch.push_back(file1);
    filesToSearch.push_back(file2);
    filesToSearch.push_back(file3);

   SearchDir _currentSearch;
    //_currentSearch.SetStartPath("/home/steven/NetBeansProjects");
   _currentSearch.SetStartPath("/home/steven/netbeans-6.5");
    _currentSearch.SetFileType(filesToSearch);
    _currentSearch.SetRelevanceStyle(SD_REL_BOTH);  //TEXT, TITLE
    _currentSearch.SearchAllFiles(false);
    //_currentSearch.SetSearchString("Test1 is a filename baby, it might be txt or cpp");
    _currentSearch.SetSearchString("Test1 is a filename baby, it might be txt or cpp");
    _currentSearch.StartSearch();
    _currentSearch.DisplayAllFiles();
    return (EXIT_SUCCESS);
}

