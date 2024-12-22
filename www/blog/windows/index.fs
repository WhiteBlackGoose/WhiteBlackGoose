module www.blog.windows.index

open Giraffe.ViewEngine
open Page

let orderedHeader =
    let mutable counter = 0
    fun text ->
        counter <- counter + 1
        Text $"{counter}. {text}"

let orderedHeader2 =
    let mutable counter = 0
    fun (text : string) ->
        counter <- counter + 1
        Text $"{counter}. {text}"

let refancs anc text =
    refanc anc text |> RenderView.AsString.htmlNode

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Why I hate Windows"
 url = "blog/windows"
 filename = "index.html"
 contents = [
  p [] [
   Text $"""
   This is my rant about Windows. What I use instead is {_a (Utils.locAwarePath www.blog.nixos.index.html.url) "NixOS" }.
   """
  ]
  br []
  hr []
  br []

  h2 [] [ anc "install"; orderedHeader "Annoying installation" ]
  p [] [
   Text "The newest versions will try to force you to connect to the internet and then login with a Microsoft account. If you don't have internet, there's no button to avoid it, you must find a way to connect to the internet. There's a hack: you need to press Shift+F10 in that page and type OOBE\BYPASSNRO. Really?"
  ]

  h2 [] [ anc "controlled"; orderedHeader $"""Proprietary and controlled single-handedly""" ]
  p [] [
   Text $"""
   They will decide what you want. They will try by default to trick you into creating a Microsoft account (upon installation). Later they decide, which software can or can't be installed or uninstalled. For example, you can't easily remove Edge, MS Store, XBox something, Explorer, etc.
   """
  ]

  h2 [] [ anc "monolithic"; orderedHeader "Monolithic nature" ]
  p [] [
   Text $"""
   Windows seems to be designed in a way, that things like Task Bar, Start Menu, Desktop, Window Manager, Login Screen and others are integral parts of it. So naturally, you can't replace them, or it will be a workaround or hacky solution. { _a "https://github.com/lars-berger/GlazeWM" "GlazeWM" } is doing a good job providing users a tiling WM experience. But it works on top of the existing ones, and things aren't always synced (e. g. entries on your desktop may as well overlap with the bar provided by this WM).
   """
  ]

  h2 [] [ anc "updates"; orderedHeader "Updates" ]
  p [] [
   Text $"""
   This is the most intrusive issue. They're automatic and you can't {it "disable"} them. At most - postpone. You're forced to choose active hours, which are supposedly fixed for every person (which isn't true at all), and you can't choose them more than some fixed amount of hours.
   """
  ]
  p [] [
    Text $"""
    Real life story. I turn my laptop into sleep mode and go sleep myself. It decides to wake up at 02:00 and starts updating stuff, waking me up as well (bc it runs loud fans). I'm annoyed and sleeping suspending it again... and guess what, in 5-30 minutes (I don't remember exactly) it wakes up again. What a fucking annoying piece of shit.
    """
  ]
  p [] [
    Text $"""
    Another pain point with forced updates is that I can't leave my laptop doing something for a night. I tried a few times just to find out every time that Windows decided to shut down killing all my processes for an update.
    """
  ]
  p [] [
    Text $"""
    It's also trying to push updates through power buttons. You want to restart? "Restart and update". You want to shut down? "Shut down and update". Or you decided to shut down some time ago, now turn your laptop on before a conference, and Windows decided to update...
    """
  ]


  h2 [] [ anc "packages"; orderedHeader "Package management" ]
  p [] [
    Text $"""
    Most software for Windows is installed through installers. It has a whole bunch of drawbacks:
    """
    ul [] [
      li [] [ Text "You have to find these installers on the internet" ]
      li [] [ Text "Installers are not audited, unless you build your own" ]
      li [] [ Text "Software makers have to work on installers besides the app" ]
      li [] [ Text "You have to rely on uninstallers to delete unnecessary stuff" ]
      li [] [ Text "Installers cannot manage dependencies in a single way and have to duplicate dependencies" ]
    ]
  ]
  p [] [
    Text $"""
    Choco, WinGet exist and provide some relief to it. But next most popular way (after installers) for app distribution is MS Store. Which is proprietary, paid, and not moderated properly, allowing {_a "https://answers.microsoft.com/en-us/windows/forum/all/why-microsoft-store-is-full-of-scam-apps/8c759f96-44a8-40e0-b987-7db7c0f711da" "tons of scam"}. So naturally it's a hassle for both users and developers to use MS Store.
    """
  ]
  p [] [
    Text $"""Then again, WinGet is also not the ultimate solution. There's no ultimate convention on how software should be consumed by users. 'C:/Program Files' exists, but every app is packed in its own folder, so you have to add the full path to it in the $PATH variable yourself. As a result, if you, for example, install neovim via winget, you won't be able to invoke it with just 'nvim'. You need to add it to $PATH."""
  ]

  h2 [] [ anc "config"; orderedHeader "Configuration" ]
  p [] [
    Text $"""It's good to have GUI for configuration. But in Windows, many things are GUI-only. For example, registry (it has API for editing, but no "just text file")."""
  ]

  h2 [] [ anc "tech"; orderedHeader "Not tech friendly" ]
  p [] [
    Text $"""Now this is not a fault of Windows per se, but stil a reason why I don't want to use it. I'm an SWE and a massive nerd. ...."""
  ]

  p [_style "text-align: center"] [
   Text "Work In Progress..."
  ]
 ]
}
