package com.itminds.PatternC;

public abstract class Bar {
    protected  Foo foo;

    protected Bar(Foo foo) {
        this.foo = foo;
    }

    public abstract void update();
}
