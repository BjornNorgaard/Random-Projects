package com.itminds.PatternB;


public class  PatternB implements IPatternB {
    public ISomeObject Create() {
        return new ConcreteSomeObject();
    }
}


/* Write your answers and comments below this line

*/