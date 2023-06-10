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

type Value =
    | High
    | Medium
    | Low

type Contribution =
    | Created
    | Major
    | Minor

type ProjectTile =
    { name : string
      url : string
      langs : ProgrammingLanguage list
      value : Value
      contrib : Contribution }

let myProjects = [
    { name = "AngouriMath"; url = "https://am.angouri.org";
    langs = [ CSharp; FSharp ]; value = High; contrib = Created }

    { name = "CodegenAnalysis"; url = "https://github.com/WhiteBlackGoose/CodegenAnalysis";
    langs = [ CSharp ]; value = Medium; contrib = Created }

    { name = "GenericTensor"; url = "https://github.com/asc-community/GenericTensor";
    langs = [ CSharp ]; value = Medium; contrib = Created }

    { name = "HonkPerf.NET"; url = "https://github.com/asc-community/HonkPerf.NET";
    langs = [ CSharp ]; value = Medium; contrib = Created }

    { name = "brownian-motion-chart"; url = "https://github.com/WhiteBlackGoose/brownian-motion-chart";
    langs = [ Rust ]; value = Low; contrib = Created }

    { name = "LambdaCalculusFSharp"; url = "https://lambda.wbg.gg";
    langs = [ FSharp ]; value = High; contrib = Created }

    { name = "FStar.Lib.NET"; url = "https://github.com/WhiteBlackGoose/FStar.Lib.NET";
    langs = [ FStar; FSharp ]; value = Low; contrib = Created }

    { name = "FsMinimalWebpageTemplate"; url = "https://github.com/WhiteBlackGoose/FsMinimalWebpageTemplate";
    langs = [ FSharp ]; value = Low; contrib = Created }

    { name = "json2fs"; url = "https://github.com/WhiteBlackGoose/json2fs";
    langs = [ FSharp ]; value = Medium; contrib = Created }

    { name = "AsmToDelegate"; url = "https://github.com/WhiteBlackGoose/AsmToDelegate";
    langs = [ CSharp; FSharp ]; value = Low; contrib = Created }

    { name = "InductiveVariadics"; url = "https://github.com/WhiteBlackGoose/InductiveVariadics";
    langs = [ CSharp ]; value = Low; contrib = Created }

    { name = "dotnet-proj"; url = "https://github.com/WhiteBlackGoose/dotnet-proj";
    langs = [ FSharp ]; value = Low; contrib = Created }

    { name = "MoreFuncUI"; url = "https://github.com/WhiteBlackGoose/MoreFuncUI";
    langs = [ FSharp ]; value = Low; contrib = Created }

    { name = "UnitsOfMeasure"; url = "https://github.com/WhiteBlackGoose/UnitsOfMeasure";
    langs = [ CSharp ]; value = Low; contrib = Created }

    { name = "tri"; url = "https://github.com/WhiteBlackGoose/tri"; 
    langs = [ Rust ]; value = Medium; contrib = Created }

    { name = "lamca"; url = "https://github.com/WhiteBlackGoose/lamca"; 
    langs = [ Haskell ]; value = Low; contrib = Created }

    { name = "frac-hs"; url = "https://github.com/WhiteBlackGoose/frac-hs"; 
    langs = [ Haskell ]; value = Low; contrib = Created }

    { name = "my-nix"; url = "https://github.com/WhiteBlackGoose/my-nix";
    langs = [ Nix ]; value = Low; contrib = Created }

    { name = "draco-nvim"; url = "https://github.com/Draco-lang/draco-nvim";
    langs = [ Draco; Lua ]; value = Low; contrib = Created }

    { name = "Silk.NET"; url = "https://github.com/dotnet/Silk.NET";
    langs = [ CSharp ]; value = High; contrib = Minor }

    { name = "Plotly.NET"; url = "https://github.com/plotly/Plotly.NET/"; 
    langs = [ FSharp ]; value = High; contrib = Major }

    { name = "nixpkgs"; url = "https://github.com/NixOS/nixpkgs";
    langs = [ Nix ]; value = High; contrib = Minor }

    { name = ".NET Interactive"; url = "https://github.com/dotnet/interactive";
    langs = [ CSharp ]; value = Medium; contrib = Minor }

    { name = "Draco"; url = "https://github.com/Draco-lang/Language-suggestions";
    langs = [ Draco ]; value = Low; contrib = Minor }

    { name = "advanced-git-search"; url = "https://github.com/WhiteBlackGoose/advanced-git-search.nvim";
    langs = [ Lua ]; value = Medium; contrib = Minor }

    { name = "nvim-latex-preconfig"; url = "https://github.com/WhiteBlackGoose/nvim-latex-preconfig";
    langs = [ Lua; LaTeX ]; value = Low; contrib = Created }

    { name = "nvim-web-icons"; url = "https://github.com/nvim-tree/nvim-web-devicons";
    langs = [ Lua ]; value = High; contrib = Minor }

    { name = "orgmode"; url = "https://github.com/nvim-orgmode/orgmode";
    langs = [ Lua ]; value = High; contrib = Minor }

    { name = "TWIN"; url = "https://github.com/phaazon/this-week-in-neovim-contents";
    langs = [ ]; value = High; contrib = Minor }

    { name = "barbar.nvim"; url = "https://github.com/romgrk/barbar.nvim";
    langs = [ Lua ]; value = High; contrib = Minor }
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
            let ics = List.map lang2icon prj.langs |> List.map (fun f -> f "15")
            let l = a [_href prj.url; _style "margin-left: 5px"] [ Text prj.name ] 
            match prj.contrib, prj.value with
            | Created, High | Major, High ->
                div [ _style "border-radius: 5px; border: 1px solid gray;" ] [ yield! ics; l ]
            | _, High -> b [] [ yield! ics; l ]
            | _ -> 
                yield! ics
                l
        ]
    ]
]

let html = PageWrap.wrap www.``static``.styles.css {
    title = "List of projects"
    url = "projects"
    filename = "index.html"
    contents = [
        h2 [] [ Text "I made..." ]
        yield! List.filter (fun p -> p.contrib = Created) myProjects |> projectsListHtml

        h2 [] [ Text "My major contributions are..." ]
        yield! List.filter (fun p -> p.contrib = Major) myProjects |> projectsListHtml

        h2 [] [ Text "My minor contributions are..." ]
        yield! List.filter (fun p -> p.contrib = Minor) myProjects |> projectsListHtml
    ]
}
