module www.projects.index

open Giraffe.ViewEngine
open Page

type ProgrammingLanguage = CSharp | FSharp | FStar | Bash | Rust

type ProjectTile =
    { name : string
      url : string
      langs : ProgrammingLanguage list }

let projects = [
    { name = "AngouriMath"; url = "https://github.com/asc-community/AngouriMath";
    langs = [ CSharp; FSharp ] }

    { name = "CodegenAnalysis"; url = "https://github.com/WhiteBlackGoose/CodegenAnalysis";
    langs = [ CSharp ] }

    { name = "GenericTensor"; url = "https://github.com/asc-community/GenericTensor";
    langs = [ CSharp ] }

    { name = "HonkSharp"; url = "https://github.com/WhiteBlackGoose/HonkSharp";
    langs = [ CSharp ] }

    { name = "HonkPerf.NET"; url = "https://github.com/asc-community/HonkPerf.NET";
    langs = [ CSharp ] }

    { name = "nix-utils"; url = "https://github.com/WhiteBlackGoose/nix-utils";
    langs = [ Bash ] }

    { name = "brownian-motion-chart"; url = "https://github.com/WhiteBlackGoose/brownian-motion-chart";
    langs = [ Rust ] }

    { name = "LambdaCalculusFSharp"; url = "https://github.com/WhiteBlackGoose/LambdaCalculusFSharp";
    langs = [ FSharp ] }

    { name = "FStar.Lib.NET"; url = "https://github.com/WhiteBlackGoose/FStar.Lib.NET";
    langs = [ FSharp; FStar ] }

    { name = "FsMinimalWebpageTemplate"; url = "https://github.com/WhiteBlackGoose/FsMinimalWebpageTemplate";
    langs = [ FSharp ] }

    { name = "json2fs"; url = "https://github.com/WhiteBlackGoose/json2fs";
    langs = [ FSharp ] }

    { name = "AsmToDelegate"; url = "https://github.com/WhiteBlackGoose/AsmToDelegate";
    langs = [ CSharp; FSharp ] }

    { name = "InductiveVariadics"; url = "https://github.com/WhiteBlackGoose/InductiveVariadics";
    langs = [ CSharp ] }

    { name = "dotnet-proj"; url = "https://github.com/WhiteBlackGoose/dotnet-proj";
    langs = [ FSharp ] }

    { name = "MoreFuncUI"; url = "https://github.com/WhiteBlackGoose/MoreFuncUI";
    langs = [ FSharp ] }

    { name = "UnitsOfMeasure"; url = "https://github.com/WhiteBlackGoose/UnitsOfMeasure";
    langs = [ CSharp ] }

    { name = "ConsoleGameEngine"; url = "https://github.com/WhiteBlackGoose/ConsoleGameEngine";
    langs = [ CSharp ] }

    { name = "GuessBigO"; url = "https://github.com/WhiteBlackGoose/GuessBigO";
    langs = [ CSharp ] }
]

let projectsListHtml = [
    ul [] [
    for prj in projects do
        li [] [ a [_href prj.url] [ Text prj.name ] ]
    ]
]

let html = PageWrap.wrap www.``static``.styles.css {
    title = "List of projects"
    url = "projects"
    filename = "projects.html"
    contents = [
        yield! projectsListHtml
    ]
}
