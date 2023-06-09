module www.projects.index

open Giraffe.ViewEngine
open Page

type ProgrammingLanguage = 
    | CSharp 
    | FSharp
    | FStar 
    | Bash
    | Rust
    | Nix
    | Haskell
    | Draco
    | Lua
    | LaTeX

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

    { name = "LambdaCalculusFSharp"; url = "https://lambda.wbg.gg";
    langs = [ FSharp ] }

    { name = "FStar.Lib.NET"; url = "https://github.com/WhiteBlackGoose/FStar.Lib.NET";
    langs = [ FStar; FSharp ] }

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

    { name = "tri"; url = "https://github.com/WhiteBlackGoose/tri"; 
    langs = [ Rust ] }

    { name = "lamca"; url = "https://github.com/WhiteBlackGoose/lamca"; 
    langs = [ Haskell ] }

    { name = "frac-hs"; url = "https://github.com/WhiteBlackGoose/frac-hs"; 
    langs = [ Haskell ] }

    { name = "my-nix"; url = "https://github.com/WhiteBlackGoose/my-nix";
    langs = [ Nix ]}

    { name = "draco-nvim"; url = "https://github.com/Draco-lang/draco-nvim";
    langs = [ Draco; Lua ] }
]

let contributedProjects = [
    { name = "Silk.NET"; url = "https://github.com/dotnet/Silk.NET";
    langs = [ CSharp ] }

    { name = "Plotly.NET"; url = "https://github.com/plotly/Plotly.NET/"; 
    langs = [ FSharp ] }

    { name = "nixpkgs"; url = "https://github.com/NixOS/nixpkgs";
    langs = [ Nix ]}

    { name = ".NET Interactive"; url = "https://github.com/dotnet/interactive";
    langs = [ CSharp ] }

    { name = "Draco"; url = "https://github.com/Draco-lang/Language-suggestions";
    langs = [ Draco ] }

]

let neovimProjects = [
    { name = "advanced-git-search"; url = "https://github.com/WhiteBlackGoose/advanced-git-search.nvim";
    langs = [ Lua ]}

    { name = "nvim-latex-preconfig"; url = "https://github.com/WhiteBlackGoose/nvim-latex-preconfig";
    langs = [ Lua; LaTeX ] }

    { name = "nvim-web-icons"; url = "https://github.com/nvim-tree/nvim-web-devicons";
    langs = [ Lua ]}

    { name = "orgmode"; url = "https://github.com/nvim-orgmode/orgmode";
    langs = [ Lua ]}

    { name = "TWIN"; url = "https://github.com/phaazon/this-week-in-neovim-contents";
    langs = [ ]}

    { name = "barbar.nvim"; url = "https://github.com/romgrk/barbar.nvim";
    langs = [ Lua ] }
]

let lang2icon = function
    | CSharp  -> www.``static``.media.icons.CSharp
    | FSharp  -> www.``static``.media.icons.FSharp
    | FStar   -> www.``static``.media.icons.FStar
    | Bash    -> www.``static``.media.icons.Bash
    | Rust    -> www.``static``.media.icons.rust
    | Nix     -> www.``static``.media.icons.NixOS
    | Haskell -> www.``static``.media.icons.haskell
    | Draco   -> www.``static``.media.icons.Draco
    | Lua     -> www.``static``.media.icons.lua
    | LaTeX   -> www.``static``.media.icons.LaTeX

let projectsListHtml prjList = [
    ul [_style "column-count: 3; list-style-type: none"] [
    for prj in (prjList |> List.sortBy (fun p -> p.name.ToLower())) do
        li [] [ 
            for ic in List.map lang2icon prj.langs do
                ic "15"
            a [_href prj.url; _style "margin-left: 5px"] [ Text prj.name ] ]
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

        h2 [] [ Text "Neovim-related" ]
        yield! projectsListHtml neovimProjects
    ]
}
