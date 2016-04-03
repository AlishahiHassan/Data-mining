
// ----------------------------------------------------- min Hashing -------------------


static int hCount = 100;						// number of hash functions
static int[] hashCoef = new int[hCount+1];		// ax+b -> a = zarayebe hash
static int[] hashPlus = new int[hCount+1];		// ax+b -> b

public void CreateHashFunctions()
{
	Random r = new Random(DateTime.Now.Millisecond);
	for (int i = 1; i <= hCount; i++)
	{
		hashCoef[i] = r.Next(1, 20000);
		hashPlus[i] = r.Next(1, 20000);
	}
}

public int hash(int id, int x)
{
	return (hashCoef[id] * x + hashPlus[id]) % 20003;
}

class A
{
	public bool f1, f2;

	public A(bool F1,bool F2) { f1 = F1; f2 = F2; }
}

void RandomList(List<A> l)
{
	Random r = new Random(DateTime.Now.Millisecond);
	int count = l.Count;
	for (int i = 0; i < count; i++)
	{
		int j = r.Next(0, count);
		A a = l[i];
		l[i] = l[j];
		l[j] = a;
	}
}

public double MinHashing(int x, int y,int k)
{

	string path, s;
	int len;

	SortedSet<string> sa = new SortedSet<string>();
	path = Form1.dataPath + x.ToString() + ".doc";
	s = File.ReadAllText(path).Replace(" ", "");
	len = s.Length - k + 1;
	for (int i=0 ; i<len ; i++)
	{
		string t = s.Substring(i,k);
		if (sa.Contains(t) == false)
			sa.Add(t);
	}

	SortedSet<string> sb = new SortedSet<string>();
	path = Form1.dataPath + y.ToString() + ".doc";
	s = File.ReadAllText(path).Replace(" ", "");
	len = s.Length - k + 1;
	for (int i = 0; i < len; i++)
	{
		string t = s.Substring(i, k);
		if (sb.Contains(t) == false)
			sb.Add(t);
	}

	SortedDictionary<string,A> table = new SortedDictionary<string,A>();
	foreach (string i in sa)
		table.Add(i , new A(true,false));

	foreach (string i in sb)
	{
		if (table.ContainsKey(i) == false)
			table.Add(i, new A(false, true));
		else
			table[i].f2 = true;
	}

	double[,] p = new double[hCount+1, 3];     // 5 , 2
	for (int i = 0; i < hCount + 1; i++) for (int j = 0; j < 3; j++) p[i, j] = 30000;

	int q = 0;
	int[] v = new int[hCount + 1];
	foreach (KeyValuePair<string, A> i in table)
	{
		for (int j = 1; j <= hCount; j++) v[j] = hash(j, q);
		if (i.Value.f1)
		{
			for (int j=1 ; j<=hCount ; j++)
				p[j, 1] = Math.Min(p[j, 1], v[j]);
		}
		if (i.Value.f2)
		{
			for (int j = 1; j <= hCount; j++)
				p[j, 2] = Math.Min(p[j, 2], v[j]);
		}

		q++;
	}

	double same = 0.0;
	for (int j = 1; j <= hCount; j++)
		if (p[j,1]!=30000 && p[j, 1] == p[j, 2]) same += 1.0;

	return same / (double)hCount;
}
