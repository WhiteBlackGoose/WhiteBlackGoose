module www.blog.angourimath_deprecation.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
    title = "AngouriMath Deprecation: End of Journey"
    url = "angourimath-deprecation"
    filename = "index.html"
    contents = [
        p [] [ Text "It has been a fun journey. AngouriMath was started as a school project in 2019. I learned a lot about C#, .NET, and programming during this time. Sadly, I haven't had time to maintain it for two last years and I don't see it change any time soon, so I'm deprecating it." ]
        h2 [] [ anc "whatnow"; Text "What should we, users, do?" ]
        p [] [ Text "Feel free to keep using it, but there won't be any work from me anymore. You can also migrate to an alternative, or maintain a fork of AngouriMath." ]
        h2 [] [ anc "archive"; Text "Archive?" ]
        p [] [ Text "I'm not going to archive it, people are free to interact with it however they want, I don't care." ]
        h2 [] [ anc "newmaintainer"; Text "I want to continue this work" ]
        p [] [ Text "If you want to continue working on this project, make a fork and work on it. If that stays afloat for some time, feel free to contact me (you'll find my contacts on the main page) and we can probably make you a maintainer of the AngouriMath repo." ]
    ]
}
