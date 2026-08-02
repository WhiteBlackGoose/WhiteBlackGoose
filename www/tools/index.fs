module www.tools.index

open Giraffe.ViewEngine
open Page

type OnlineTool =
    { name : string
      domain : string
      url : string
      description : string
      live : bool }

let onlineTools = [
    { name = "Libre DISC"; domain = "disc.wbg.gg"; url = "https://disc.wbg.gg";
      description = "A free, open-source DISC personality test covering 16 personality types. No signup, no tracking."
      live = true }

    { name = "germany-finances"; domain = "finances-de.wbg.gg"; url = "https://finances-de.wbg.gg";
      description = "Visualize how income tax works in Germany."
      live = true }

    { name = "super-trader"; domain = "supertrader.wbg.gg"; url = "https://supertrader.wbg.gg";
      description = "A fun little game where you try to outsmart the market."
      live = true }

    { name = "travel-map"; domain = "travel-map.wbg.gg"; url = "https://travel-map.wbg.gg";
      description = "Create a map of places you've been to, and share it."
      live = false }

    { name = "LambdaCalculusWeb"; domain = "lambda.wbg.gg"; url = "https://lambda.wbg.gg";
      description = "An interactive lambda calculus evaluator, made purely in F#."
      live = true }
]

let html = PageWrap.wrap www.``static``.styles.css {
    title = "Free online tools"
    url = "tools"
    filename = "index.html"
    contents = [
        p [] [
            Text "A handful of small "
            a [_href "https://www.gnu.org/philosophy/free-sw.en.html"] [ Text "free" ]
            Text " and open-source web tools I've made, all hosted under "
            code [_class "code-inline"] [ Text "*.wbg.gg" ]
            Text ". Free forever, no accounts, no tracking."
        ]
        div [_class "tool-grid"] [
            for tool in onlineTools do
                a [_href tool.url; _class "tool-card"] [
                    span [_class "tool-name"] [ Text tool.name ]
                    span [_class "tool-domain"] [ Text tool.domain ]
                    span [_class "tool-desc"] [ Text tool.description ]
                    if not tool.live then
                        span [_class "tool-badge"] [ Text "coming soon" ]
                ]
        ]
    ]
}
