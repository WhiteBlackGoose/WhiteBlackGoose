module www.projects.index

open Giraffe.ViewEngine
open Page

type ProgrammingLanguage = CSharp | FSharp | FStar | Bash | Rust | Nix

type ProjectTile =
    { name : string
      url : string
      langs : ProgrammingLanguage list }

let myProjects = [
    { name = "AngouriMath"; url = "https://github.com/asc-community/AngouriMath";
    langs = [ CSharp; FSharp ] }

    { name = "CodegenAnalysis"; url = "https://github.com/WhiteBlackGoose/CodegenAnalysis";
    langs = [ CSharp ] }

    { name = "GenericTensor"; url = "https://github.com/asc-community/GenericTensor";
    langs = [ CSharp ] }

    { name = "HonkPerf.NET"; url = "https://github.com/asc-community/HonkPerf.NET";
    langs = [ CSharp ] }

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
]

let contributedProjects = [
    { name = "Silk.NET"; url = "https://github.com/dotnet/Silk.NET";
      langs = [ CSharp ] }

    { name = "Plotly.NET"; url = "https://github.com/plotly/Plotly.NET/"; 
      langs = [ FSharp ] }

    { name = "nixpkgs"; url = "https://github.com/NixOS/nixpkgs";
      langs = [ Nix ]}

    { name = ".NET Interactive"; url = "https://github.com/dotnet/interactive"; langs = [ CSharp ] }

    { name = "Draco"; url = "https://github.com/Draco-lang/Language-suggestions"; langs = [ ] }
]

let projectsListHtml prjList = [
    ul [_style "column-count: 3"] [
    for prj in prjList do
        li [] [ a [_href prj.url] [ Text prj.name ] ]
    ]
]

let html = PageWrap.wrap www.``static``.styles.css {
    title = "List of projects"
    url = "projects"
    filename = "index.html"
    contents = [
        h2 [] [ Text "I made..." ]
        yield! projectsListHtml myProjects

        h2 [] [ Text "I contributed to..." ]
        yield! projectsListHtml contributedProjects
    ]
}
