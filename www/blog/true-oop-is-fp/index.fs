module www.blog.true_oop_is_fp.index

open Giraffe.ViewEngine
open Page
open PageWrap

let html = wrap www.``static``.styles.css {
    title = "True OOP is FP"
    url = "blog/true-oop-is-fp"
    filename = "index.html"
    contents = [
     p [] [
       Text "🚧 WIP 🚧"
     ]
     p [] [ Text "People contrast "; abbr [ _title "Object-Oriented Programming" ] [ Text "OOP" ]; Text " languages to "; abbr [ _title "Functional Programming" ] [ Text "FP" ]; Text ". In my opinion, only bad OOP is mutually exclusive with FP. Instead, good OOP happens to be a subset of FP!" ]
    ]
}
