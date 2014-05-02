@echo off

for %%F in ( *.in ) do (
    ..\bin\Debug\FastSort.exe <%%F >%%~nF.actual
    fc %%~nF.actual %%~nF.expected
)