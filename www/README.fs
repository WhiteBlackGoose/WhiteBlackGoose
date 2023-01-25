module www.README

open PageWrap
open Giraffe.ViewEngine

let html : WrappedPage = {
    title = ""
    url = ""
    filename = "README.md"
    contents = p [] [
        h1 [] [ Text "Hi, it's WhiteBlackGoose" ]
        Text $"""
I'm a member of <a href="https://angouri.org">Angouri</a>, <a href="http://dotnetfoundation.org">.NET Foundation</a>, and <a href="https://www.fsf.org">Free Software Foundation</a>, and author of <a href="http://github.com/asc-community/AngouriMath">AngouriMath</a>. 

I'm a Free Software enthusiast and mainly work on FOSS projects.

The rest please see my [personal website](https://wbg.angouri.org) (requires no javascript).
        """
    ]
}
