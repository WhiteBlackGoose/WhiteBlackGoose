module InternalArticles.Pass

open Giraffe.ViewEngine
open InternalArticleDef

let page = {
    title = "Pass - password manager for geeks"
    contents = [
        h2 [] [ Text "Why?" ]
        p [] [
            ul [] [
                li [] [ Text "✔️  CLI interface only, no need for GUI" ]
                li [] [ Text "✔️  Works natively on Unix-like systems" ]
                li [] [ Text "✔️  Has many clients for mainstream OS" ]
                li [] [ Text "✔️  Only famous FOSS tools (used utils: `git`, `pass`, `gpg`, `openssh`, `passphrase2pgp`)" ]
                li [] [ Text "✔️  No Google/Facebook account or other BS integration, your credentials are yours and stored by you on your computer" ]
                li [] [ Text "✔️  Knowing your primary password is not enough to access your passwords" ]
                li [] [ Text "✔️  Still can sync among devices" ]
                li [] [ Text "✔️  You control where your backup stored (and it's encrypted too)" ]
                li [] [ Text "X That's 100x more complicated to set up than most crappy password managers you'd find on the internet"  ]
            ]
        ]

        h2 [] [ Text "1. Intro to pass" ]
        p [] [
            Text $"""This {ur "https://www.passwordstore.org/" "tool"} provides an amazingly easy-to-use interface. Available for most major Unix-like operating systems (basically every desktop OS except Windows)."""
        ]
        p [] [
            Text "Install it how it's shown in the website."
        ]
        p [] [
            Text "Get started:"
            ul [] [
                li [] [ 
                    Text $"""`gpg --full-generate-key` to generate key using GPG. In the end it will return something like `myname <mymail@quack.org>`, remember this, it's your *Key ID*. Let it be `user1` for now (assuming you skipped mail). You will be asked to input a passphrase - that's what your private key will be decrypted with, make sure to remember it!""" ]
                li [] [ 
                    Text $"""`pass init user1` inits your password store (input the key ID from the previous step).""" ]
                li [] [ 
                    Text $"""`pass insert website/username` creates a prompt where you input your password.""" ]
                li [] [
                    Text $"""`pass website/username` retrieves it. `pass -c website/username` retrives it into clipboard.""" ]
            ]
        ]
        p [] [
            Text "Now, there are two approaches:"
            ul [] [
                refanc "another-user" "Syncing with another user"
                refanc "another-comp" "Syncing with another computer"
            ]
        ]
    ]
}
