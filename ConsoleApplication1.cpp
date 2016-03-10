// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <algorithm>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int max,min,n,c,mod=0,index=0,k=-1;
	float Q1,Q2,outlier,Q3,*x,*y;
	cin>>n;
	x=new float[n];
	y=new float[n];
	for(int i=0;i<n;i++)
		cin>>x[i];
	/////////////////////////////////////////////////////////////////sort
	sort(x,x+n);
	min=x[0];
	max=x[n-1];
	for(int i=0;i<n;i++)
		cout<<x[i]<<" ";
	
	if(n%2!=0)
	{
		Q2=x[ n/2];
		Q3=x[((n/2)+n)/2];
		Q1=x[n/4];
	}
	else
	{
		Q2=(x[(n-1)/2]+x[((n-1)/2)+1])/2;
		c=n-(n/2);
		if(c%2!=0)
		{
			Q3=x[(c/2)+(n/2)];
			Q1=x[n/4];
		}
		else
		{
			int p=((n/2)+(c/2));
			Q3=(x[p]+x[p-1])/2;
			 p=((n/2)-(c/2));
			 Q1=(x[p]+x[p-1])/2;
		}
	}
	//////////////////////////////////////////////////////////////////////mod
	for(int i=0;i<n;i++)
		y[i]=0;

	for(int i=0,counter=0,j=0;i<n-1;i++)
	{
		if(x[i]==x[i+1])
		{
			j=i;
			counter++;
		}
		else
		{
			y[j]=counter;
			counter=0;
		}
	}
	
	for (int i = 0; i < n; i++)
	{
		if(mod<y[i])
		{
			mod=y[i];
			index=i;
		}
	}
	////////////////////////////////////////////////////////////////outLier
	outlier=1.5*(Q3-Q1);
	for(int i=0;i<n;i++)
	{
		if(x[i]>outlier)
		{
			outlier=x[i];
			k=i;
			break;
		}
	}
	cout<<'\n'<<"min = "<<min<<'\n'<<"max = "<<max<<'\n';
	cout<<"Q1="<<Q1<<'\n';
	cout<<"Q2="<<Q2<<'\n';
	 cout<<"Q3="<<Q3<<'\n';
	 cout<<"mod="<<x[index]<<'\n';
	 if(k!=-1)
	{
		for(int i=k;i<n;i++)
			cout<<x[i]<<"  ";
	}
	/*int a[5] = {1,6,7,2,4};
	sort(a , a+5);
	for (int i=0 ; i<5 ; i++) cout<<a[i]<<" ";
	*/
	cin.get(); cin.get();
	return 0;
}

