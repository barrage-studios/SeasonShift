# Contributing to SeasonShift!
### Table of Contents
[Pre-requisites](#pre-requisites)
  * [Knowledge](#knowledge)
  * [Tools](#tools)
  * [Access](#access)

[Code Submission](#code-submission)
  * [Rules](#rules)
  * [How to submit](#how-to-submit)
  * [Style guides](#style-guides)
  * [Branch Structure](#branch-structure)
  * [File Structure](#file-structure)
  
## Pre-Requisites
### Knowledge (aka things that help to know beforehand)
  * Git 2.0
  * Unity 2019.2.6f1
  * C#
  * How to make sprite art
  * How to make 8/16-bit sound

### Tools
  * Unity 2019.2.6f1
  * Visual Studio 2019
  * Git enabled VCS tool
    - Git for Unity
    - Git CMD
    - Github Visual Studio Extension
    - Github Desktop
  * Photoshop or GIMP
  * FL Studio or Audacity

### Access
Only code/assets from pre-approved persons can contribute to this project as of this  
moment in time. (this is exclusively inclusive of [ITGD-Mondays](https://github.com/intro-to-game-dev-mondays) members)
  
## Code Submission
### Rules  

**1.** Code is not to be submitted to the `master` or `development` branch directly  
**2.** New features are to be submitted using a `feature` branch attached to `development`  
**3.** Quick fixes must be submitted using a `fix` branch attached to `dev`  
**4.** Only branches that pass CI will be merged  
**5.** Feature and commit names must be clear  
**6.** Always pull before you push  
**7.** If you get a merge conflict, consult the person whose code is in conflict with yours  
**8.** All pull requests are to be accepted only by approved persons  
**9.** <u>If you are ever confused ask for help, don't just hope you use the right git command</u>

### How to submit

If you have an idea thats not already in development and hasn't been assigned to  
anyone, please go ahead and create a feature branch for this code {IN PROGRESS}

### Style Guides
# NEEDS TO BE FILLED OUT  

### Branch Structure  
```
master
|
|\developement
| |
| |\feature/...
| | |
| | |
| |/Merge dev<-feat
| |
| |\fix/...
| | |
| | |
| |/Merge dev<-fix
|/Merge master<-dev
|
↓
```
### File Structure  
```
root
|
|->GlobalAssets
|    |->Scripts
|    |    |->Script.cs
|    |->Visuals
|    |    |->Art.png
|    |->Sounds
|        |->Sound.wav
|
|->SpringAssets
|    |->Scripts
|    |    |->Script.cs
|    |->Visuals
|    |    |->Art.png
|    |->Sounds
|        |->Sound.wav
|
|...More Seasons and other folders
|
|->.gitignore
|->README.md
```
