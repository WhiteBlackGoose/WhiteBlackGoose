module www.misc.os_tierlist.index

open Giraffe.ViewEngine
open Page
open www.``static``.media.icons

let html = PageWrap.wrap www.``static``.styles.css {
 title = "My tier list of operating systems"
 url = "misc/os-tierlist"
 filename = "index.html"
 contents = [
  p [] [ Text "This isn't meant to be serious. Also I haven't tried a tiny fraction of all OS." ]
  let sz = "30"
  let liIcons = List.map (fun ic -> td [] [ic sz])
  let trStyle = _style "border-bottom: 1px solid gray; margin-bottom: 5px"
  table [] [
   tr [trStyle] [ 
    td [] [ Text "Best" ]
    yield! liIcons [ NixOS ]
   ]
   tr [trStyle] [ 
    td [] [ Text "Great" ]
    yield! liIcons [ fedora; xubuntu ]
   ]
   tr [trStyle] [ 
    td [] [ Text "Not bad" ]
    yield! liIcons [ debian; arch; mint ]
   ]
   tr [trStyle] [ 
    td [] [ Text "Ewww" ]
    yield! liIcons [ FreeBSD; kubuntu; ubuntu ]
   ]
   tr [trStyle] [ 
    td [] [ Text "Bad" ]
    yield! liIcons [ Windows; Android ]
   ]
   tr [trStyle] [ 
    td [] [ Text "Garbage" ]
    yield! liIcons [ iOS ]
   ]
  ]
 ]
}
