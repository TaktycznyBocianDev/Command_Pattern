public interface ICommand 
{
    //Basic interface for command pattern. Every specific command have to implement those methods.

    public void Execute();

    public void Undo();
}
