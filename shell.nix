{ pkgs ? import <nixpkgs> {} }:
  pkgs.mkShell {
    nativeBuildInputs = [ pkgs.dotnetCorePackages.sdk_6_0 ];
}
