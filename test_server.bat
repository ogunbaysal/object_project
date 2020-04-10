pushd server
start dotnet run
popd
pushd server_test
dotnet test
popd
pause 