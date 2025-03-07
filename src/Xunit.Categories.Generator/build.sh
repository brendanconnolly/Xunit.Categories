dotnet test
dotnet run 
#ls -l
pwd
cp -a ./output/Xunit.Categories/. ../Xkitties.Catz/
cp -a ./output/Xunit.Categories.Test/. ../test/Xkitties.Catz.Test/
cd ../Xkitties.Catz.Test/
dotnet test
cd ../Xkitties.Catz.Generator
ls
rm -r ./output
cd ..
git add '*.cs'
git commit -m 'adding generated category'


## on push run this