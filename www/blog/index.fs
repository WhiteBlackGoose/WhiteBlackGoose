module www.blog.index

open Giraffe.ViewEngine
open Page

type Lang = EN | RU

type ArticleTile = 
    { lang : Lang
      tags : string list
      link : string
      title : string
      date : string
    }

let articles = [
    { lang = EN; date = "2023-01-28"; tags = [ "gnu"; "nixos" ]; title = www.blog.nixos.index.html.title;
        link = Utils.locAwarePath www.blog.nixos.index.html.url }

    { lang = EN; date = "2022-10-12"; tags = [ "cybersecurity"; "gnu" ]; title = www.blog.pass.index.html.title;
        link = Utils.locAwarePath www.blog.pass.index.html.url }

    { lang = EN; date = "2022-10-10"; tags = [ "life" ]; title = www.blog.yyyy_mm_dd.index.html.title;
        link = Utils.locAwarePath www.blog.yyyy_mm_dd.index.html.url }

    { lang = EN; date = "2022-07-20"; tags = [ "web"; "F#" ]; title = "Create static website yourself. No 3rd party services";
        link = "https://dev.to/whiteblackgoose/create-static-website-yourself-no-3rd-party-services-1314" }

    { lang = EN; date = "2022-06-02"; tags = [ "politics"; "philosophy" ]; title = www.blog.what_the_world_could_be_like.index.html.title;
        link = Utils.locAwarePath www.blog.what_the_world_could_be_like.index.html.url }

    { lang = EN; date = "2022-05-28"; tags = [ "python"; "investing" ]; title = "20 Random Stocks Investment Strategy";
        link = "https://wbg.angouri.org/media/20_random_stocks.html" }

    { lang = EN; date = "2022-02-22"; tags = [ "best"; "recursion" ]; title = "Don’t underestimate Recursion: it’s far more powerful, than most people think";
        link = "https://whiteblackgoose.medium.com/dont-underestimate-recursion-it-s-far-more-powerful-than-most-people-think-130a1077f3a6" }

    { lang = EN; date = "2022-02-06"; tags = [ "best"; "F#"; "asm"; "perf" ];  title = "Inline Assembly in F#! How does it work?";
        link = "https://blog.devgenius.io/inline-assembly-in-f-net-language-6d70ab9f58c1" }

    { lang = EN; date = "2022-01-31"; tags = [ "best"; "C#"; "perf" ];         title = "This is how Variadic Arguments could work in C#";
        link = "https://whiteblackgoose.medium.com/this-is-how-variadic-arguments-could-work-in-c-e2034a9c241" }
    
    { lang = RU; date = "2022-01-30"; tags = [ "best"; "C#"; "perf" ];   title = "Как LINQ, только быстрый и без аллокаций";
        link = "https://habr.com/ru/post/648529" }
    
    { lang = EN; date = "2022-01-03"; tags = [ "best"; "C#"; "perf" ];         title = "Like Regular LINQ, but Faster and Without Allocations: Is It Possible?";
        link = "https://whiteblackgoose.medium.com/3d4724632e2a" }
    
    { lang = RU; date = "2021-12-23"; tags = [ "best"; "C#"; "F#" ];   title = "Очень типобезопасно! Концепт продвинутой расширяемой системы единиц измерения с generic math для .NET";
        link = "https://habr.com/ru/post/597437/" }
    
    { lang = EN; date = "2021-12-22"; tags = [ "best"; "C#"; "F#" ];   title = "Stay safe with your units! Advanced units of measure in .NET.";
        link = "https://whiteblackgoose.medium.com/stay-safe-with-your-units-advanced-units-of-measure-in-net-f7d8b02af87e" }
    
    { lang = EN; date = "2021-09-02"; tags = [ "best"; "C#"; "perf" ]; title = "Making loop \"foreach\" as fast as \"for\"";
        link = "https://habr.com/en/post/575916/" }
    
    { lang = RU; date = "2021-09-01"; tags = [ "best"; "C#"; "perf" ]; title = "Ускоряем цикл foreach до for";
        link = "https://habr.com/ru/post/575664/" }
    
    { lang = RU; date = "2021-07-05"; tags = [ "C#"; "wasm" ]; title = "Хостим WASM-приложения на github pages в два клика";
        link = "https://habr.com/ru/post/566286/" }
        
    { lang = EN; date = "2021-07-04"; tags = [ "C#"; "F#"; "math" ]; title = "AngouriMath 1.3 update";
        link = "https://habr.com/en/post/565996/" }
        
    { lang = EN; date = "2021-03-14"; tags = [ "best"; "C#" ]; title = "Compilation of symbolic expressions into Linq.Expression";
        link = "https://habr.com/en/post/546926/" }
        
    { lang = RU; date = "2021-03-13"; tags = [ "C#" ]; title = "Компилируем математические выражения";
        link = "https://habr.com/ru/post/546622/" }

    { lang = EN; date = "2021-03-08"; tags = [ "C#"; "OOP" ];  title = "Lazy Properties Are Good. That Is How You Are to Use Them";
        link = "https://habr.com/en/post/545936/" }
    
    { lang = EN; date = "2021-03-04"; tags = [ "C#"; "F#"; "math" ]; title = "What's new in AngouriMath 1.2?";
        link = "https://habr.com/en/post/545436" }
    
    { lang = RU; date = "2021-03-03"; tags = [ "C#"; "F#"; "math" ]; title = "Что нового в AngouriMath 1.2?";
        link = "https://habr.com/en/post/545190/" }

    { lang = EN; date = "---"; tags = [ "F#"; "math" ]; title = "AngouriMath for Research with F#";
        link = "https://am.angouri.org/research" }
    
    { lang = EN; date = "2021-06-19"; tags = [ "C#"; "math" ]; title = "Parsing a math expression in C#";
        link = "https://whiteblackgoose.medium.com/parsing-a-math-expression-from-string-in-c-b2b48e2ac2e6" }

    { lang = RU; date = "2020-11-23"; tags = [ "C#"; "OOP" ]; title = "Методы без аргументов — зло в ООП, и вот как его полечить";
        link = "https://habr.com/ru/post/529454/" }
    
    { lang = EN; date = "2020-11-19"; tags = [ "C#"; "F#"; "Jupyter" ]; title = "Jupyter in .NET";
        link = "https://habr.com/en/post/528816" }
    
    { lang = RU; date = "2020-11-18"; tags = [ "C#"; "F#"; "Jupyter" ]; title = "Jupyter для .NET. «Как в питоне»";
        link = "https://habr.com/ru/post/528730/" }

    { lang = EN; date = "2020-08-05"; tags = [ "C#"; "perf" ]; title = "Generic tensors in C#";
        link = "https://gist.github.com/WhiteBlackGoose/5b84b2237704a91ffe7f34372196df32" }

    { lang = RU; date = "2020-08-04"; tags = [ "C#"; "perf" ]; title = "Тензоры для C#. И матрицы, и векторы, и кастомный тип, и сравнительно быстро";
        link = "https://habr.com/ru/post/512856/" }
    
    { lang = EN; date = "2020-02-01"; tags = [ "C#"; "math" ]; title = "Symbolic algrebra in C#";
        link = "https://habr.com/en/post/486496" }
    
    { lang = RU; date = "2020-01-09"; tags = [ "C#"; "math" ]; title = "Пишем «калькулятор». Часть II. Решаем уравнения, рендерим в LaTeX, ускоряем функции до сверхсветовой";
        link = "https://habr.com/ru/post/483294/" }
    
    { lang = RU; date = "2020-01-03"; tags = [ "C#"; "math" ]; title = "Пишем «калькулятор» на C#. Часть I. Вычисление значения, производная, упрощение, и другие гуси";
        link = "https://habr.com/ru/post/482228/" }

    { lang = RU; date = "2019-09-25"; tags = [ "python"; "math" ]; title = "Играемся с комплексными числами";
        link = "https://habr.com/ru/post/468781/" }
    
    { lang = RU; date = "2019-09-19"; tags = [ "python"; "math" ]; title = "Генератор простых арифметических примеров для чайников и не только";
        link = "https://habr.com/ru/post/468457/" }

    { lang = RU; date = "2019-09-18"; tags = [ "python" ]; title = "Элементарная симуляция кастомного физического взаимодействия на python + matplotlib";
        link = "https://habr.com/ru/post/467803/" }

    { lang = EN; date = "2019-09-01"; tags = [ "python" ]; title = "Yet another snake with Kivy, Python";
        link = "https://habr.com/en/post/465523" }
    
    { lang = EN; date = "---"; tags = [ "python" ]; title = "Simple simulation of custom physical interactions with particles";
        link = "https://dzone.com/articles/a-simple-simulation-of-custom-physical-interaction" }
]

let articlesListHtml = 
    [
        for lang in [ EN; RU ] do
            h2 [] [ anc (lang.ToString().ToLower()); Text $"Articles in lang {lang}" ]
            table [] [
                tr [] [ th [] [ Text "Date" ]; th [] [ Text "Url" ] ]
                for article in List.filter (fun a -> a.lang = lang) articles do
                    tr [] [ td [] [ Text article.date ]; td [] [ a [_href article.link ] [ Text article.title ] ] ]
            ]
    ]

let html = PageWrap.wrap www.``static``.styles.css {
    title = "List of articles"
    url = "blog"
    filename = "index.html"
    contents = [
        yield! articlesListHtml 
    ]
}
