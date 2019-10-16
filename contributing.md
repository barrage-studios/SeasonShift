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
### Guidelines and Rules 
**0.** ***ONLY COMMIT YOUR WORK, NEVER COMMIT FOR OTHERS***  
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
> This tutorial is specifically for GitHub Desktop Version 2.2.1  
> Note: Other versions may have minor differences in procedure

**1.** Access branch list
<img src="https://i.imgur.com/8xGkTK7.png" width="550" height="378">  

**2.** Select the development branch  
<img src="https://i.imgur.com/5Oi38tH.png" width="550" height="378">  

**3.** Create a new branch using the `feature/xxx` `fix/xxx` naming scheme  
<img src="https://i.imgur.com/hUWsWVM.png" width="550" height="378">  

**4.** Set the parent branch to development  
<img src="https://i.imgur.com/6a5Gen9.png" width="550" height="378">  

**5.** and publish branch to github  
<img src="https://i.imgur.com/FsL1hmq.png" width="550" height="378">  

### Style Guides
 
[Coding Style](https://docs.google.com/document/d/e/2PACX-1vQGvisdq91KzV9-rU7zaC2n8Q13zkBz_J6dzhG8IJjr0-0jn9FQ8qoN5EpOMglrsbLt-yMRui-mwSlp/pub)  
[Art Style](https://docs.google.com/document/d/e/2PACX-1vTSiKjiqe05X6euX97oL98cui0QubgBPuqLtbvFEDgOrEcO9BOYGIeBxK8OshGIWb9Posbwm8oHx399/pub)  
[Site Containing all documentation](https://intro-to-game-dev-mondays.github.io/GameDocsSite)

### Branch Structure  
```
master
|
|\development
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
