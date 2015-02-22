using System;
using Akka.Actor;

namespace WinTail
{
    class Program
    {
        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            MyActorSystem = ActorSystem.Create("MyActorSystem");

            var consoleWriterActor = MyActorSystem.ActorOf(
                    Props.Create(() => new ConsoleWriterActor()),
                    "consoleWriterActor");

            var consoleReaderActor = MyActorSystem.ActorOf(
                    Props.Create(() => new ConsoleReaderActor(consoleWriterActor)),
                    "consoleReaderActor");

            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);
            MyActorSystem.AwaitTermination();
        }

    }
}
