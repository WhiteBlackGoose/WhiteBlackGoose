module Articles

type Lang = EN | RU

type ArticleTile = 
    { lang : Lang
      tags : string list
      link : string
      title : string
      date : string
      previewUrl : string Option
      }
    interface Wbg.IDated with
        member self.date = self.date

let articles = [
    { lang = EN; date = "2022-10-12"; tags = [ "cybersecurity"; "linux" ]; title = "Cheatsheet on configuring fully FOSS highly secure pass with sync-ing";
        link = "./pass/index.html";
        previewUrl = None }

    { lang = EN; date = "2022-10-10"; tags = [ "life" ]; title = "Why YYYY-MM-DD is the best date format?";
        link = "https://wbg.angouri.org/blog/yyyy-mm-dd/index.html";
        previewUrl = None }

    { lang = EN; date = "2022-07-20"; tags = [ "web"; "F#" ]; title = "Create static website yourself. No 3rd party services";
        link = "https://dev.to/whiteblackgoose/create-static-website-yourself-no-3rd-party-services-1314";
        previewUrl = Some "https://user-images.githubusercontent.com/31178401/133685389-f1126fc5-d278-4f99-9adb-3d98120f2e8c.jpeg#gh-light-mode-only" }

    { lang = EN; date = "2022-06-02"; tags = [ "politics"; "philosophy" ]; title = "What the World could be Like";
        link = "https://wbg.angouri.org/blogs/what-the-world-could-be-like/index.html";
        previewUrl = Some "https://user-images.githubusercontent.com/31178401/133685389-f1126fc5-d278-4f99-9adb-3d98120f2e8c.jpeg#gh-light-mode-only" }

    { lang = EN; date = "2022-05-28"; tags = [ "python"; "investing" ]; title = "20 Random Stocks Investment Strategy";
        link = "https://wbg.angouri.org/media/20_random_stocks.html";
        previewUrl = Some "https://user-images.githubusercontent.com/31178401/135977941-f15f2ca1-dc29-46e1-93ef-929ee0467f00.jpg" }

    { lang = EN; date = "2022-02-22"; tags = [ "best"; "recursion" ]; title = "Don’t underestimate Recursion: it’s far more powerful, than most people think";
        link = "https://whiteblackgoose.medium.com/dont-underestimate-recursion-it-s-far-more-powerful-than-most-people-think-130a1077f3a6";
        previewUrl = Some "https://miro.medium.com/max/1050/1*pGVGa8vJODJOyfpi-YcQug.png" }

    { lang = EN; date = "2022-02-06"; tags = [ "best"; "F#"; "asm"; "perf" ];  title = "Inline Assembly in F#! How does it work?";
        link = "https://blog.devgenius.io/inline-assembly-in-f-net-language-6d70ab9f58c1";
        previewUrl = Some "https://miro.medium.com/max/1148/1*cd7oSXw7sSTHeFIlzo1Llg.png" }

    { lang = EN; date = "2022-01-31"; tags = [ "best"; "C#"; "perf" ];         title = "This is how Variadic Arguments could work in C#";
        link = "https://whiteblackgoose.medium.com/this-is-how-variadic-arguments-could-work-in-c-e2034a9c241";
        previewUrl = Some "https://miro.medium.com/max/1022/1*Mcbnb1PKgyKXzUB2Frj66A.png" }
    
    { lang = RU; date = "2022-01-30"; tags = [ "best"; "C#"; "perf" ];   title = "Как LINQ, только быстрый и без аллокаций";
        link = "https://habr.com/ru/post/648529";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/d0b/e87/f38/d0be87f386e2e860533efcac2c8aa613.png" }
    
    { lang = EN; date = "2022-01-03"; tags = [ "best"; "C#"; "perf" ];         title = "Like Regular LINQ, but Faster and Without Allocations: Is It Possible?";
        link = "https://whiteblackgoose.medium.com/3d4724632e2a";
        previewUrl = Some "https://miro.medium.com/max/1194/1*vjzCXRSmBoRBjm3ANP2iTA.png" }
    
    { lang = RU; date = "2021-12-23"; tags = [ "best"; "C#"; "F#" ];   title = "Очень типобезопасно! Концепт продвинутой расширяемой системы единиц измерения с generic math для .NET";
        link = "https://habr.com/ru/post/597437/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/502/438/5a0/5024385a0fd8cfddb89ff3822f1f2428.png"}
    
    { lang = EN; date = "2021-12-22"; tags = [ "best"; "C#"; "F#" ];   title = "Stay safe with your units! Advanced units of measure in .NET.";
        link = "https://whiteblackgoose.medium.com/stay-safe-with-your-units-advanced-units-of-measure-in-net-f7d8b02af87e";
        previewUrl = Some "https://miro.medium.com/max/719/1*IZ1lFDyOld1etNTvm5Wxuw.png" }
    
    { lang = EN; date = "2021-09-02"; tags = [ "best"; "C#"; "perf" ]; title = "Making loop \"foreach\" as fast as \"for\"";
        link = "https://habr.com/en/post/575916/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/29c/ef1/eed/29cef1eed2a3b30458bb599f3d95c32e.png" }
    
    { lang = RU; date = "2021-09-01"; tags = [ "best"; "C#"; "perf" ]; title = "Ускоряем цикл foreach до for";
        link = "https://habr.com/ru/post/575664/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/aee/5a0/175/aee5a0175edb2c93e1059e35c6b37bf9.png" }
    
    { lang = RU; date = "2021-07-05"; tags = [ "C#"; "wasm" ]; title = "Хостим WASM-приложения на github pages в два клика";
        link = "https://habr.com/ru/post/566286/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/69e/3ff/2ad/69e3ff2ad85a56f793dd9f5fba0399d6.png" }
        
    { lang = EN; date = "2021-07-04"; tags = [ "C#"; "F#"; "math" ]; title = "AngouriMath 1.3 update";
        link = "https://habr.com/en/post/565996/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/169/36b/3fc/16936b3fcab2e2c445e0aa79261c96dd.png" }
        
    { lang = EN; date = "2021-03-14"; tags = [ "best"; "C#" ]; title = "Compilation of symbolic expressions into Linq.Expression";
        link = "https://habr.com/en/post/546926/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/f27/348/333/f273483338a6fe05ce78548b90eb018c.png" }
        
    { lang = RU; date = "2021-03-13"; tags = [ "C#" ]; title = "Компилируем математические выражения";
        link = "https://habr.com/ru/post/546622/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/3e6/e2b/5ba/3e6e2b5ba313b3e22e59cb45e1ac9bf4.png" }

    { lang = EN; date = "2021-03-08"; tags = [ "C#"; "OOP" ];  title = "Lazy Properties Are Good. That Is How You Are to Use Them";
        link = "https://habr.com/en/post/545936/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/2a2/ea6/556/2a2ea65569be8f6b81146805cbd7bcfb.jpg" }
    
    { lang = EN; date = "2021-03-04"; tags = [ "C#"; "F#"; "math" ]; title = "What's new in AngouriMath 1.2?";
        link = "https://habr.com/en/post/545436";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/580/212/e20/580212e20734d8eaa6f98243b6edc8eb.PNG" }
    
    { lang = RU; date = "2021-03-03"; tags = [ "C#"; "F#"; "math" ]; title = "Что нового в AngouriMath 1.2?";
        link = "https://habr.com/en/post/545190/";
        previewUrl = Some "https://habrastorage.org/getpro/habr/upload_files/19e/ed1/d23/19eed1d2329b7a7ddc868069b624c6d8.PNG" }

    { lang = EN; date = "---"; tags = [ "F#"; "math" ]; title = "AngouriMath for Research with F#";
        link = "https://am.angouri.org/research";
        previewUrl = Some "https://user-images.githubusercontent.com/31178401/135977941-f15f2ca1-dc29-46e1-93ef-929ee0467f00.jpg" }
    
    { lang = EN; date = "2021-06-19"; tags = [ "C#"; "math" ]; title = "Parsing a math expression in C#";
        link = "https://whiteblackgoose.medium.com/parsing-a-math-expression-from-string-in-c-b2b48e2ac2e6";
        previewUrl = Some "https://miro.medium.com/max/1200/1*3mqFwJ5ewsPtFZx9QK4CWw.png" }

    { lang = RU; date = "2020-11-23"; tags = [ "C#"; "OOP" ]; title = "Методы без аргументов — зло в ООП, и вот как его полечить";
        link = "https://habr.com/ru/post/529454/";
        previewUrl = Some "https://habr.com/share/publication/529454/a07bc18b3e38fbad05c9b78f111300ad/" }
    
    { lang = EN; date = "2020-11-19"; tags = [ "C#"; "F#"; "Jupyter" ]; title = "Jupyter in .NET";
        link = "https://habr.com/en/post/528816";
        previewUrl = Some "https://habr.com/share/publication/528816/582c32b46b6e002e2eedebcb5329c567/" }
    
    { lang = RU; date = "2020-11-18"; tags = [ "C#"; "F#"; "Jupyter" ]; title = "Jupyter для .NET. «Как в питоне»";
        link = "https://habr.com/ru/post/528730/";
        previewUrl = Some "https://habrastorage.org/webt/pt/-w/jw/pt-wjwicbtpcozkv46nhzmjoi0u.png"
        }

    { lang = EN; date = "2020-08-05"; tags = [ "C#"; "perf" ]; title = "Generic tensors in C#";
        link = "https://gist.github.com/WhiteBlackGoose/5b84b2237704a91ffe7f34372196df32";
        previewUrl = Some "https://github.githubassets.com/images/modules/gists/gist-og-image.png" }

    { lang = RU; date = "2020-08-04"; tags = [ "C#"; "perf" ]; title = "Тензоры для C#. И матрицы, и векторы, и кастомный тип, и сравнительно быстро";
        link = "https://habr.com/ru/post/512856/";
        previewUrl = Some "https://habr.com/share/publication/512856/fcedf4d99a99135a84557921732358c5/" }
    
    { lang = EN; date = "2020-02-01"; tags = [ "C#"; "math" ]; title = "Symbolic algrebra in C#";
        link = "https://habr.com/en/post/486496";
        previewUrl = Some "https://habr.com/share/publication/486496/20891568c4870e8b57a73a9ce74f37d5/" }
    
    { lang = RU; date = "2020-01-09"; tags = [ "C#"; "math" ]; title = "Пишем «калькулятор». Часть II. Решаем уравнения, рендерим в LaTeX, ускоряем функции до сверхсветовой";
        link = "https://habr.com/ru/post/483294/";
        previewUrl = Some "https://habr.com/share/publication/483294/ceefb0200d7a1f6dcf01f7eedc55e8a7/" }
    
    { lang = RU; date = "2020-01-03"; tags = [ "C#"; "math" ]; title = "Пишем «калькулятор» на C#. Часть I. Вычисление значения, производная, упрощение, и другие гуси";
        link = "https://habr.com/ru/post/482228/";
        previewUrl = Some "https://habr.com/share/publication/482228/c841fe42662c1c602aa27b8538c0bfd4/" }

    { lang = RU; date = "2019-09-25"; tags = [ "python"; "math" ]; title = "Играемся с комплексными числами";
        link = "https://habr.com/ru/post/468781/";
        previewUrl = Some "https://habr.com/share/publication/468781/c066cbfc2a741e5323f9beb785be5b33/" }
    
    { lang = RU; date = "2019-09-19"; tags = [ "python"; "math" ]; title = "Генератор простых арифметических примеров для чайников и не только";
        link = "https://habr.com/ru/post/468457/";
        previewUrl = Some "https://habr.com/share/publication/468457/c8f2fe61222a2b227a3b53145ad31c76/" }

    { lang = RU; date = "2019-09-18"; tags = [ "python" ]; title = "Элементарная симуляция кастомного физического взаимодействия на python + matplotlib";
        link = "https://habr.com/ru/post/467803/";
        previewUrl = Some "https://habr.com/share/publication/467803/762381688f1a95ac0bafdc1673b11a9f/" }

    { lang = EN; date = "2019-09-01"; tags = [ "python" ]; title = "Yet another snake with Kivy, Python";
        link = "https://habr.com/en/post/465523";
        previewUrl = Some "https://habr.com/share/publication/465523/9a8716eb62e422f804451a428873c8dd/" }
    
    { lang = EN; date = "---"; tags = [ "python" ]; title = "Simple simulation of custom physical interactions with particles";
        link = "https://dzone.com/articles/a-simple-simulation-of-custom-physical-interaction";
        previewUrl = Some "https://dz2cdn3.dzone.com/storage/article-thumb/12559734-thumb.jpg" }
]
