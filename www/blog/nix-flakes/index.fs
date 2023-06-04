module www.blog.nix_flakes.index

open Giraffe.ViewEngine
open Page
open PageWrap

let precode c = pre [] [ code [] c ]

let html = wrap www.``static``.styles.css {
 title = "Intro in Nix & Flakes"
 url = "blog/nix-flakes"
 filename = "index.html"
 contents = [
  p [] [
   Text "This is yet another attempt to explain flakes"
  ]
  br []
  hr []
  br []
  h2 [] [ Text "flake.nix is just a simple set" ]
  p [] [
   Text "What some people fail to explain that the set described by flake.nix, to be precise,"
   precode [
    Text """{
 inputs.quack1.url = "aaa";
 inputs.quack2.url = "aaa";
 outputs = { quack1, quack2, ... }: {
  ...
 }
}"""
   ]
   Text "is merely an actual set. Not special. You can add any fields there."
  ]
  h2 [] [ Text "But nix3 commands interpret certain fields specially" ]
  p [] [
   Text $"""Flake is merely a set, but nix3 commands, like {co "nix develop"}, {co "nix shell"}, and so on, interpret it in a certain way. When they {it "evaluate"} a flake, they collect all input URLs, fetch them, evaluate them, and substitute into {co "outputs"}. The evaluated value of {co "outputs"} is the evaluated value of flake according to nix3 commands."""
  ]
  h2 [] [ Text "Let's play around flake" ]
  p [] [
   Text "Let's create a very simple flake:"
   precode [
    Text "{
  outputs = { self, ... }: {
    sum-of-two = a: b: a + b;
  };
}"
   ]
   Text "There's no inputs, and there's only one output field. Let's import it as a nix file if you don't believe me:"
   precode [
    Text "$> nix repl

nix-repl> f = import ./flake.nix

nix-repl> f
{ outputs = «lambda @ /home/goose/trash/flake-playground/sum-of-two/flake.nix:2:13»; }
"
   ]
   Text "See? This is exactly how we define it. We defined it as a set with one attribute. Outputs is a function, just like we defined. We can even evaluate it ourselves, manually. Look:"
   precode [
    Text "nix-repl> (f.outputs { self = f; }).sum-of-two 4 5
9"
   ]
   Text "But all because it has a special format (and name flake.nix), we can also load it as flake into our repl:"
   precode [
    Text "nix-repl> :lf .
Added 9 variables."
   ]
   Text $"""It evaluated the flake and put its evaluated value into variable called {co "outputs"}. Let's see its value:"""
   precode [
    Text "nix-repl> outputs
{ sum-of-two = «lambda @ /nix/store/qzf8wd8nj8ajsrrxazs338ysz62f9yai-source/flake.nix:3:18»; }

nix-repl> outputs.sum-of-two 4 5
9"
   ]
   Text $"""Yep, it evaluted to what we expected. We didn't depend on the input, so it just returned the set that we return in function {co "outputs"}."""
  ]
  h2 [] [ Text "What about inputs?" ]
  p [] [
   Text $"""Let's create another flake in another folder. I call the older one {co "two-of-sum"} and the new one {co "main"}. The folder structure is:"""
   precode [
    Text "$> find .
.
./sum-of-two
./sum-of-two/flake.nix
./main
./main/flake.nix"
   ]
   Text $"""And {co "./main/flake.nix"} is defined:"""
   precode [
    Text """$> cat flake.nix
{
  inputs.sum.url = "path:/home/goose/trash/flake-playground/sum-of-two";
  outputs = { sum, ... }: {
    heh = sum.sum-of-two 4 5;
  };
}"""
   ]
   Text "Now we added the other flake as input and return an set where one field is sum of 4 and 5 taken from the other flake. Now we need to lock the file to ensure that the inputs don't change on their own:"
   precode [
    Text "$> nix flake lock
warning: creating lock file '/home/goose/trash/flake-playground/main/flake.lock'"
   ]
   Text "Now let's enter the flake, evaluate it, and see the value:"
   precode [
    Text """$> nix repl
Welcome to Nix 2.13.3. Type :? for help.

nix-repl> :lf .
Added 9 variables.

nix-repl> outputs
{ heh = 9; }"""
   ]
   Text $"""See? {co "sum"} input was evaluated and substituted into {co "outputs"}. The evaluated flake {co "sum"} has field {co "sum-of-two"}, which is what we call inside in ours."""
  ]
  h2 [] [ Text "What's up with shells and nixosConfigurations and packages?" ]
  p [] [
   Text $"""Basically, commands like {co "nix develop"}, {co "nix shell"} etc. merely evaluate the flake and interpret certain fields. Which fields? Depends on the command. For example, {co "nix develop"} looks for field/attribute {co "devShells"}. To see which commands expect which fields, {_a "https://nixos.wiki/wiki/Flakes#Output_schema" "see output schema"}."""
  ]
 ]
}
