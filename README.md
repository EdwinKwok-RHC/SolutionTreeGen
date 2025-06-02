
# SolutionTreeGen
Generate Folder/Files tree of a dotnet solution. All runtime objects are excluded

# Usage 
SolutionTreeGen E:\ekwok\POC\RagWithSharePoint_Poc  /A /F

## Parameters
	/F: Print folders and files.
	/A: Exclude files and folders inside any bin and obj folders.
	
# Sample Output
- SolutionTreeGen
  - SolutionTreeGen
    - Program.cs
    - SolutionTreeGen.csproj
  - README.md
  - SolutionTreeGen.sln