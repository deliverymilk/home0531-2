
#include <iostream>

using namespace std;

class A
{
public :

	A()
	{
		cout << "A 생성자" << endl;
	}

	virtual void VirtualFunction()
	{
		cout << "A 클래스의 가상 함수" << endl;
	}

	void Function()
	{
		cout << "A 클래스의 함수" << endl;
	}

	~A()
	{
		cout << "A 소멸자" << endl;
	}
};


class B : public A
{
public:
	B()
	{
		cout << "B 생성자" << endl;
	}

	virtual void VirtualFunction()
	{
		cout << "B 클래스의 가상 함수" << endl;
	}
	void Function()
	{
		cout << "B 클래스의 함수" << endl;
	}

	~B()
	{
		cout << "B 소멸자" << endl;
	}

};

int main()
{
	//B b;
	//b.Function();

	A* ptr = new B;

	ptr->VirtualFunction();
	ptr->Function();
}

