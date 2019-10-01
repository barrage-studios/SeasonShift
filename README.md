> Github Rules  

**1.** No submitting code to the `master` or `dev` branch  
**2.** New featuresbe submitted using a `feature` branch attached to `dev`  
**3.** Quick fixes must be submitted using a `fix` branch attached to `dev`  
**4.** Only branches that pass CI will be merged  
**5.** Feature and commit names must be clear  
**6.** Always pull before you push  
**7.** If you get a merge conflict, consult the person whose code is in conflict with yours  
**8.** All pull requests are to be accepted only by approved persons  
**9.** <u>If you are ever confused ask for help, don't just hope you use the right git command</u>

> Approved Github Managers  

- **Dominik Rutter**  
- **You, if you decide to learn github**

> Branch Structure  
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
> File Structure  
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