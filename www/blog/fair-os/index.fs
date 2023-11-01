module www.blog.fair_os.index

open Giraffe.ViewEngine
open Page

let refancs anc text =
    refanc anc text |> RenderView.AsString.htmlNode

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Laptop Manufacturers Must Provide a Free OS Option"
 url = "blog/fair-os"
 filename = "index.html"
 contents = [
  p [] [
   Text $"""
   This is my proposal and "RFC".
   """
  ]
  br []
  hr []
  br []

  h2 [] [ anc "problem"; Text $"""Problem""" ]
  p [] [
   Text $"""
   Windows dominates the desktop market. MacOS dominates the market of the Apple's hardware. Both of them exploit it in one way or another, offering their own software and abusing the unfair advantage of the duopoly.
   """
  ]
  p [] [
   Text $"""In particular, both of them are pushing their own web browsers with their own software on top of it, and even then take advantage over illiterate user (for example, installing rare applications would get the installer blocked on Microsoft Edge with the warning "this application is not commonly downloaded"). MacOS forces you to buy an Apple's PC, and it's against their ToS to install it on non-Apple's PCs.
   """
  ]

  h2 [] [ anc "idea"; Text $"""Idea""" ]
  p [] [
   Text $"""
   The idea is to force/encourage laptop manufacturers offer either a Free OS or No OS option for every model offered, and these options have to be cheaper than the one shipped with Windows. This way, more users' attention will be drawn to free operating systems. Moreover, because laptop manufacturers will be compelled to offer such an option, we will likely see significant investment in free operating systems and providing alternatives for Windows and macOS.
   """
  ]

  h2 [] [ anc "model"; Text "Possible Model" ]
  p [] [
   Text "The approach I suggest is a combination of carrot and stick."
  ]
  h3 [] [ anc "stick"; Text "Requirements" ]
  p [] [
   ul [] [
    li [] [ Text "Every laptop sold with Windows is also offered without non-free software." ]
    li [] [ Text "The price of the laptop with Windows is higher by the price of the corresponding Windows license (but no more than 20%)." ]
    li [] [ Text $"""macOS: {it "TODO"}""" ]
   ]
  ]
  h3 [] [ anc "carrot"; Text "Reward" ]
  p [] [
   ul [] [
    li [] [ Text $"""Let {it "L"} be the difference in prices of the laptop with and without Windows. Then, for every sold laptopt without, the company gets {it "L/3"} subsidy.""" ]
   ]
  ]

  h2 [] [ anc "outcome"; Text "Expected Outcome" ]
  p [] [
   ul [] [
    li [] [ Text "People who only need basic software will be switching away from Windows to save money" ]
    li [] [ Text "Laptop manufacturers will invest effort and money into making Free OS more and more user-friendly" ]
    li [] [ Text "Due to the nature of the limitation, they won't invent another Windows or macOS" ]
    li [] [ Text "With investments, devs will make more/better software for free OS" ]
   ]
  ]
 ]
}
