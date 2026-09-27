module www.web_projects.index

open Giraffe.ViewEngine
open Page

type WebProject =
    { name : string
      domain : string
      url : string
      description : string }

let tools = [
    { name = "Libre DISC"; domain = "disc.wbg.gg"; url = "https://disc.wbg.gg";
      description = "A free, open-source DISC personality test covering 16 personality types. No signup, no tracking." }

    { name = "germany-finances"; domain = "finances-de.wbg.gg"; url = "https://finances-de.wbg.gg";
      description = "Visualize how income tax works in Germany." }

    { name = "travel-map"; domain = "travel-map.wbg.gg"; url = "https://travel-map.wbg.gg";
      description = "Create a map of places you've been to, and share it." }

    { name = "LambdaCalculusWeb"; domain = "lambda.wbg.gg"; url = "https://lambda.wbg.gg";
      description = "An interactive lambda calculus evaluator, made purely in F#." }
]

let games = [
    { name = "super-trader"; domain = "supertrader.wbg.gg"; url = "https://supertrader.wbg.gg";
      description = "A fun little game where you try to outsmart the market." }

    { name = "Lumenrift"; domain = "lumenrift.wbg.gg"; url = "https://lumenrift.wbg.gg";
      description = "A tower defense game. Keep the Beacon alight through thirty nights of shadow." }
]

let private grid (projects : WebProject list) =
    div [_class "tool-grid"] [
        for project in projects do
            a [_href project.url; _class "tool-card"] [
                span [_class "tool-name"] [ Text project.name ]
                span [_class "tool-domain"] [ Text project.domain ]
                span [_class "tool-desc"] [ Text project.description ]
            ]
    ]

let html = PageWrap.wrap www.``static``.styles.css {
    title = "Web projects"
    url = "web-projects"
    filename = "index.html"
    contents = [
        p [] [
            Text "A handful of small "
            a [_href "https://www.gnu.org/philosophy/free-sw.en.html"] [ Text "free" ]
            Text " and open-source web projects I've made, all hosted under "
            code [_class "code-inline"] [ Text "*.wbg.gg" ]
            Text ". Free forever, no accounts, no tracking."
        ]
        h2 [] [ Text "Tools" ]
        grid tools
        h2 [] [ Text "Games" ]
        grid games
    ]
}
