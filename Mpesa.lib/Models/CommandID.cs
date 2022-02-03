namespace mpesa.lib.Models;

public class CommandID{
   public string Command {get; set;}
   private string Description {get; set;}

   public override string ToString(){
      return Command;
   }
}
