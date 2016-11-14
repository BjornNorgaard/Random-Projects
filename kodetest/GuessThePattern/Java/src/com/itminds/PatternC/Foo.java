package com.itminds.PatternC;

import java.util.ArrayList;

public abstract class Foo {
    private ArrayList<Bar> _list = new ArrayList<Bar>();

    public void attach(Bar bar) {
        _list.add(bar);
    }

    public void detach(Bar bar) {
        _list.remove(bar);
    }

    public void Notify() {
        for (Bar o : _list){
            o.update();
        }
    }
}

/* Write your answers and comments below this line

*/
