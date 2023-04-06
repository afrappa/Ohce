// See https://aka.ms/new-console-template for more information

using Ohce;

var ohce = new Ohce.Ohce(new ConsoleImpl(), new TimeImpl(), new StringReverser(), new PalindromeDetector());
ohce.Run(args[0]);