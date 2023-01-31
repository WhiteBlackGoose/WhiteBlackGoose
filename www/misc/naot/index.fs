module www.misc.naot.index

open Giraffe.ViewEngine
open Page
open www.``static``.media.icons

let html = PageWrap.wrap www.``static``.styles.css {
 title = "My tier list of operating systems"
 url = "misc/naot"
 filename = "index.html"
 contents = [
  p [] [ Text "Size and single file script" ]
  let script = """
dotnet publish \
-c release \
-p:PublishAot=true \
-o ./published \
-p:SelfContained=true \
-p:PublishTrimmed=true \
-p:TrimMode=full \
-p:StripSymbols=true \
-p:IlcInvariantGlobalization=true"""
  let noRefl = """\
-p:IlcDisableReflection=true"""
  for h01, scriptText in [ "Normal", script; "No reflection", script+noRefl ] do
   for h02, mode in [ "Multiline", id; "Single line", (fun (s : string) -> s.Replace("\\\n", "")) ] do
    p [] [ Text (h01 + " " + h02) ]
    pre [] [
     code [] [
      Text (mode scriptText)
     ]
    ]
 ]
}
