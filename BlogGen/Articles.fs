module Articles

type Lang = EN | RU

type Article = {
    lang : Lang
    tags : string list
    link : string
    title : string
    date : string
}

let articles = [
    { lang = EN; date = "2022-10-12"; tags = [ "cybersecurity"; "linux" ]; title = "Cheatsheet on configuring fully FOSS highly secure pass with sync-ing";
        link = "https://gist.github.com/WhiteBlackGoose/8ffb7123b991dcc4cdafcdd574bdc3c6" }

    { lang = EN; date = "2022-10-10"; tags = [ "life" ]; title = "Why YYYY-MM-DD is the best date format?";
        link = "https://wbg.angouri.org/media/yyyy-mm-dd.html" }

    { lang = EN; date = "2022-07-20"; tags = [ "web"; "F#" ]; title = "Create static website yourself. No 3rd party services";
        link = "https://dev.to/whiteblackgoose/create-static-website-yourself-no-3rd-party-services-1314" }

    { lang = EN; date = "2022-06-02"; tags = [ "politics"; "philosophy" ]; title = "What the World could be Like";
        link = "https://wbg.angouri.org/media/eqty.html" }

    { lang = EN; date = "2022-05-28"; tags = [ "python"; "investing" ]; title = "20 Random Stocks Investment Strategy";
        link = "https://wbg.angouri.org/media/20_random_stocks.html" }

    { lang = EN; date = "2022-02-22"; tags = [ "recursion" ]; title = "Don’t underestimate Recursion: it’s far more powerful, than most people think";
        link = "https://whiteblackgoose.medium.com/dont-underestimate-recursion-it-s-far-more-powerful-than-most-people-think-130a1077f3a6" }

    { lang = EN; date = "2022-02-06"; tags = [ "F#"; "asm"; "perf" ];  title = "Inline Assembly in F#! How does it work?";
        link = "https://blog.devgenius.io/inline-assembly-in-f-net-language-6d70ab9f58c1" }

    { lang = EN; date = "2022-01-31"; tags = [ "C#"; "perf" ];         title = "This is how Variadic Arguments could work in C#";
        link = "https://whiteblackgoose.medium.com/this-is-how-variadic-arguments-could-work-in-c-e2034a9c241" }
    
    { lang = RU; date = "2022-01-30"; tags = [ "C#"; "perf" ];   title = "Как LINQ, только быстрый и без аллокаций";
        link = "https://habr.com/ru/post/648529";  }
    
    { lang = EN; date = "2022-01-03"; tags = [ "C#"; "perf" ];         title = "Like Regular LINQ, but Faster and Without Allocations: Is It Possible?";
        link = "https://whiteblackgoose.medium.com/3d4724632e2a" }
    
    { lang = RU; date = "2022-12-23"; tags = [ "C#"; "F#" ];   title = "Очень типобезопасно! Концепт продвинутой расширяемой системы единиц измерения с generic math для .NET";
        link = "https://habr.com/ru/post/597437/" }
    
    { lang = EN; date = "2022-12-22"; tags = [ "C#"; "F#" ];   title = "Stay safe with your units! Advanced units of measure in .NET.";
        link = "https://whiteblackgoose.medium.com/stay-safe-with-your-units-advanced-units-of-measure-in-net-f7d8b02af87e" }
    
    { lang = EN; date = "2022-09-02"; tags = [ "C#"; "perf" ]; title = "Making loop \"foreach\" as fast as \"for\"";
        link = "https://habr.com/en/post/575916/" }
    
    { lang = RU; date = "2022-09-01"; tags = [ "C#"; "perf" ]; title = "Ускоряем цикл foreach до for";
        link = "https://habr.com/ru/post/575664/" }
    
    { lang = RU; tags = [ "C#"; "wasm" ]; title = "Хостим WASM-приложения на github pages в два клика";
        link = "https://habr.com/ru/post/566286/" }
    
    { lang = RU; tags = [ "C#" ];         title = "Компилируем математические выражения";
        link = "https://habr.com/ru/post/546622/" }
    
    { lang = EN; tags = [ "C#"; "F#"; "math" ]; title = "AngouriMath 1.3 update";
        link = "https://habr.com/en/post/565996/" }
    
    { lang = EN; tags = [ "C#" ];         title = "Compilation of symbolic expressions into Linq.Expression";
        link = "https://habr.com/en/post/546926/" }
    
    { lang = EN; tags = [ "C#"; "OOP" ];  title = "Lazy Properties Are Good. That Is How You Are to Use Them";
        link = "https://habr.com/en/post/545936/" }
    
    { lang = EN; tags = [ "F#"; "math" ]; title = "AngouriMath for Research with F#";
        link = "https://am.angouri.org/research" }
    
    { lang = EN; tags = [ "C#"; "math" ]; title = "Parsing a math expression in C#";
        link = "https://whiteblackgoose.medium.com/parsing-a-math-expression-from-string-in-c-b2b48e2ac2e6" }
    
    { lang = EN; tags = [ "C#"; "F#"; "Jupyter" ]; title = "Jupyter in .NET";
        link = "https://habr.com/en/post/528816" }
    
    { lang = RU; tags = [ "C#"; "OOP" ]; title = "Методы без аргументов — зло в ООП, и вот как его полечить";
        link = "https://habr.com/ru/post/529454/" }
    
    { lang = RU; tags = [ "C#"; "F#"; "Jupyter" ]; title = "Jupyter для .NET. «Как в питоне»";
        link = "https://habr.com/ru/post/528730/" }

    { lang = RU; tags = [ "C#"; "F#"; "math" ]; title = "Что нового в AngouriMath 1.2?";
        link = "https://habr.com/en/post/545190/" }

    { lang = EN; tags = [ "C#"; "F#"; "math" ]; title = "What's new in AngouriMath 1.2?";
        link = "https://habr.com/en/post/545436" }
    
    { lang = RU; tags = [ "C#"; "perf" ]; title = "Тензоры для C#. И матрицы, и векторы, и кастомный тип, и сравнительно быстро";
        link = "https://habr.com/ru/post/512856/" }
    
    { lang = EN; tags = [ "C#"; "perf" ]; title = "Generic tensors in C#";
        link = "https://gist.github.com/WhiteBlackGoose/5b84b2237704a91ffe7f34372196df32" }

    { lang = EN; tags = [ "C#"; "math" ]; title = "Symbolic algrebra in C#";
        link = "https://habr.com/en/post/486496" }
    
    { lang = RU; tags = [ "C#"; "math" ]; title = "Пишем «калькулятор». Часть II. Решаем уравнения, рендерим в LaTeX, ускоряем функции до сверхсветовой";
        link = "https://habr.com/ru/post/483294/" }
    
    { lang = RU; tags = [ "C#"; "math" ]; title = "Пишем «калькулятор» на C#. Часть I. Вычисление значения, производная, упрощение, и другие гуси";
        link = "https://habr.com/ru/post/482228/" }
    
    { lang = EN; tags = [ "python" ]; title = "Simple simulation of custom physical interactions with particles";
        link = "https://dzone.com/articles/a-simple-simulation-of-custom-physical-interaction" }
    
    { lang = RU; tags = [ "python" ]; title = "Элементарная симуляция кастомного физического взаимодействия на python + matplotlib";
        link = "https://habr.com/ru/post/467803/" }
    
    { lang = EN; tags = [ "python" ]; title = "Yet another snake with Kivy, Python";
        link = "https://habr.com/en/post/465523" }
    
    { lang = RU; tags = [ "python"; "math" ]; title = "Играемся с комплексными числами";
        link = "https://habr.com/ru/post/468781/" }
    
    { lang = RU; tags = [ "python"; "math" ]; title = "Генератор простых арифметических примеров для чайников и не только";
        link = "https://habr.com/ru/post/468457/" }
]
