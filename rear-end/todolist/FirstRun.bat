::创建解决方案目录
::mkdir todolist
cd ./

::创建解决方案
dotnet new sln -n todolist

::按照clean architecture的项目结构，创建WebApi项目以及classlib项目
dotnet new webapi -f net6.0 -n todolist.Api -o ./src/todolist.Api
dotnet new classlib -f net6.0 -n todolist.Application -o ./src/todolist.Application
dotnet new classlib -f net6.0 -n todolist.Domain -o ./src/todolist.Domain
dotnet new classlib -f net6.0 -n todolist.Infrastructure -o ./src/todolist.Infrastructure

::按照clean architecture的结构和依赖关系，设置项目间的引用
::Application只依赖于Domain
dotnet add src/todolist.Application/todolist.Application.csproj reference src/todolist.Domain/todolist.Domain.csproj
::Infrastructure只依赖于Application
dotnet add src/todolist.Infrastructure/todolist.Infrastructure.csproj reference src/todolist.Application/todolist.Application.csproj
::Api依赖于Application和Infrastructure
dotnet add src/todolist.Api/todolist.Api.csproj reference src/todolist.Application/todolist.Application.csproj
dotnet add src/todolist.Api/todolist.Api.csproj reference src/todolist.Infrastructure/todolist.Infrastructure.csproj

::将所有项目添加到sln上
dotnet sln todolist.sln add src/todolist.Api/todolist.Api.csproj
dotnet sln todolist.sln add src/todolist.Application/todolist.Application.csproj
dotnet sln todolist.sln add src/todolist.Domain/todolist.Domain.csproj
dotnet sln todolist.sln add src/todolist.Infrastructure/todolist.Infrastructure.csproj

::运行项目
start todolist.sln
