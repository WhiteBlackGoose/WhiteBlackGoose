module Pages

open Articles
open Giraffe.ViewEngine

type Content =
    | Article ArticleTile
    | Project ProjectTile

type FilterPage = {
    contentFilter : ContentType -> bool
    description : XmlNode list
    title : string
}

type TextPage = {
    title : string
    contents : XmlNode list
}

type Page =
    | FilterPage of FilterPage
    | TextPage of TextPage

type PageInfo = {
    page : Page
    name : string
}

let back = a [_href ".."] [ Text "🏠 Home" ]

let filterArticle func = function
    | Article art -> func art
    | _ -> false

let filterArticleByTag tag =
    filterArticle (fun { tags = tags } -> List.contains tag tags)

let filterArticleByLang langr =
    filterArticle (fun { lang = lang } -> lang == langr)


let pages : PageInfo list = [
    {
        name = "."
        page = FilterPage {
            title = "All articles"
            articleFilter = (fun _ -> true)
            description = [
                p [] [ Text """
                    Hi. I'm WhiteBlackGoose. I write articles about F#, C#, .NET (and sometimes other things).
                    """ ]
                p [] [
                    Text $"""With the same username you can find me on """
                    a [_href "https://github.com/WhiteBlackGoose"] [ Text "github" ]
                    Text ", "
                    a [_href "https://twitter.com/WhiteBlackGoose"] [ Text "twitter" ]
                    Text ", "
                    a [_href "https://whiteblackgoose.medium.com"]  [ Text "medium" ]
                    Text ", "
                    a [_href "https://reddit.com/u/WhiteBlackGoose"] [ Text "reddit" ]
                    Text "."
                ]
                p [] [ 
                    Text "This website is made via F#'s "
                    a [_href "https://github.com/giraffe-fsharp/Giraffe.ViewEngine"] [ Text "Giraffe.ViewEngine" ]
                    Text "."
                ]
                p [] [ 
                    Text "Filters: "
                    a [_href "./en"] [ Text "en" ]; Text ", "
                    a [_href "./ru"] [ Text "ru" ]; Text ", "
                    a [_href "./best"] [ Text "Best" ]; Text ", "
                    a [_href "./csharp"] [ Text "C#" ]; Text ", "
                    a [_href "./fsharp"] [ Text "F#" ]; Text ", "
                    a [_href "./perf"] [ Text "Performance" ]
                    Text "."
                ]
            ]
        }
    }
    {
        name = "csharp"
        page = FilterPage {
            title = "Articles about C#"
            articleFilter = filterArticleByTag "C#"
            description = [
                p [] [ Text "C# is the first programming language I learned well." ]
                back
            ]
        }
    }
    {
        name = "fsharp"
        page = FilterPage {
            title = "Articles about F#"
            articleFilter = filterArticleByTag "F#"
            description = [
                p [] [
                    Text "I started doing awesome language F# thanks to" 
                    a [_href "https://github.com/Happypig375"] [ Text "Happypig375" ]
                    Text "."
                ]
                back
            ]
        }
    }
    {
        name = "perf"
        page = FilterPage {
            title = "Performance-related articles"
            articleFilter = filterArticleByTag "perf"
            description = [
                p [] [
                    Text "These articles are related to performance/efficiency of the code"
                ]
                back
            ]
        }
    }
    {
        name = "ru"
        page = FilterPage {
            title = "Статьи на русском"
            articleFilter = filterArticleByLang RU
            description = [
                p [] [
                    Text "Статьи на русском."
                ]
                back
            ]
        }
    }
    {
        name = "en"
        page = FilterPage {
            title = "Articles in English"
            articleFilter = filterArticleByLang EN
            description = [
                p [] [
                    Text "Articles in English"
                ]
                back
            ]
        }
    }
    {
        name = "best"
        page = FilterPage {
            title = "My best articles"
            articleFilter = filterArticleByTag "best"
            description = [
                p [] [
                    Text "Out of all mine, these articles in my opinion deserve the most attention"
                ]
                back
            ]
        }
    }
    {
        name = "about"
        page = TextPage {
            title = "About WhiteBlackGoose"
            contents = [
                p [] []
            ]
        }
    }
]
