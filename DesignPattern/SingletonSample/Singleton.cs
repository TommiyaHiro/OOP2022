using System;

public class Singleton {

    private static Singleton singleton;
    
    //�R���X�g���N�^
    private Singleton() {                                 
        Console.WriteLine("�C���X�^���X�𐶐����܂����B");
    }

    public static Singleton getInstance() {
        if(singleton == null) {
            singleton = new Singleton();
        }
        return singleton;
    }
}
