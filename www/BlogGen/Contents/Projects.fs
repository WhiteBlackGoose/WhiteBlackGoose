module Projects

type ProgrammingLanguage = CSharp | FSharp | FStar | Bash | Rust

type ProjectTile =
    { name : string
      url : string
      langs : ProgrammingLanguage list
      date : string }
    interface Wbg.IDated with
        member self.date = self.date

let projects = [
    { name = "AngouriMath"; url = "https://github.com/asc-community/AngouriMath";
    langs = [ CSharp; FSharp ]; date = "2022-09-29" }

    { name = "CodegenAnalysis"; url = "https://github.com/WhiteBlackGoose/CodegenAnalysis";
    langs = [ CSharp ]; date = "2022-08-19" }

    { name = "GenericTensor"; url = "https://github.com/asc-community/GenericTensor";
    langs = [ CSharp ]; date = "2022-06-10" }

    { name = "HonkSharp"; url = "https://github.com/WhiteBlackGoose/HonkSharp";
    langs = [ CSharp ]; date = "2022-10-05" }

    { name = "HonkPerf.NET"; url = "https://github.com/asc-community/HonkPerf.NET";
    langs = [ CSharp ]; date = "2022-06-10" }

    { name = "nix-utils"; url = "https://github.com/WhiteBlackGoose/nix-utils";
    langs = [ Bash ]; date = "2022-11-09" }

    { name = "brownian-motion-chart"; url = "https://github.com/WhiteBlackGoose/brownian-motion-chart";
    langs = [ Rust ]; date = "2022-10-22" }

    { name = "LambdaCalculusFSharp"; url = "https://github.com/WhiteBlackGoose/LambdaCalculusFSharp";
    langs = [ FSharp ]; date = "2022-07-01" }

    { name = "FStar.Lib.NET"; url = "https://github.com/WhiteBlackGoose/FStar.Lib.NET";
    langs = [ FSharp; FStar ]; date = "2022-06-10" }

    { name = "FsMinimalWebpageTemplate"; url = "https://github.com/WhiteBlackGoose/FsMinimalWebpageTemplate";
    langs = [ FSharp ]; date = "2022-02-14" }

    { name = "json2fs"; url = "https://github.com/WhiteBlackGoose/json2fs";
    langs = [ FSharp ]; date = "2022-02-09" }

    { name = "AsmToDelegate"; url = "https://github.com/WhiteBlackGoose/AsmToDelegate";
    langs = [ CSharp; FSharp ]; date = "2022-02-06" }

    { name = "InductiveVariadics"; url = "https://github.com/WhiteBlackGoose/InductiveVariadics";
    langs = [ CSharp ]; date = "2022-01-30" }

    { name = "dotnet-proj"; url = "https://github.com/WhiteBlackGoose/dotnet-proj";
    langs = [ FSharp ]; date = "2022-01-18" }

    { name = "MoreFuncUI"; url = "https://github.com/WhiteBlackGoose/MoreFuncUI";
    langs = [ FSharp ]; date = "2022-01-09" }

    { name = "UnitsOfMeasure"; url = "https://github.com/WhiteBlackGoose/UnitsOfMeasure";
    langs = [ CSharp ]; date = "2021-12-23" }

    { name = "ConsoleGameEngine"; url = "https://github.com/WhiteBlackGoose/ConsoleGameEngine";
    langs = [ CSharp ]; date = "2021-10-23" }

    { name = "GuessBigO"; url = "https://github.com/WhiteBlackGoose/GuessBigO";
    langs = [ CSharp ]; date = "2021-09-16" }
]