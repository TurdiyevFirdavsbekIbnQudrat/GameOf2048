using GameOf2048;
using System.Threading.Channels;

RandomSon number = new RandomSon();
Console.WriteLine("O'yin shartlari : ");
Console.WriteLine("W->yuqoriga harakat \n A->chap tomonga harakat \n S->pastga harakat \n D->o'ngga harakat");
Console.WriteLine("Maydon hajmi :");
for(int i = 2; i < 10; i+=2)
{
    Console.WriteLine("{0} : {0}x{0}",i);
} 
Console.Write("Nechanchi raqamdagi maydonni tanlaysiz : ");
int MaydonBirTomoni=Convert.ToInt32(Console.ReadLine());

int[][] Maydon = new int[MaydonBirTomoni][];
for (int i = 0; i < MaydonBirTomoni; i++)
{
    int[] n = new int[MaydonBirTomoni];
    Maydon[i] = n; 
    
}

Console.WriteLine("Boshlandi : ");

Natija(MaydonBirTomoni, Maydon);
int x = 0;
while (true)
{
    
    string Yunalish = Console.ReadLine();
    Console.Clear();
   
    if(Yunalish.Equals("W") || Yunalish.Equals("w"))
    {
        WMethod(MaydonBirTomoni,Maydon);
        
    } 
    else
    if (Yunalish.Equals("A") || Yunalish.Equals("a"))
    {
        AMethod(MaydonBirTomoni, Maydon);
    }
    else
    if (Yunalish.Equals("S") || Yunalish.Equals("s"))
    {
        SMethod(MaydonBirTomoni, Maydon);
    }
    else
    if (Yunalish.Equals("D") || Yunalish.Equals("d"))
    {
        DMethod(MaydonBirTomoni, Maydon);
    }
    
}
void Natija(int MaydonBirTomoni,params int[][]  Maydon) {
    for (int i = 0; i < MaydonBirTomoni; i++)
    {
        for (int j = 0; j < MaydonBirTomoni; j++)
        {
            Console.Write(Maydon[i][j] + "   ");
        }
        Console.WriteLine();
    } 
}


void WMethod(int MaydonTomoni,params int[][] Maydon)
{
    int[] NulBormi = new int[MaydonTomoni];
    for(int i=0; i < MaydonTomoni; i++)
    {

        List<int> nulsiz = nulsizLarniOlish( MaydonTomoni,i,Maydon);
        List<int> saralangan = SaralabOLish(nulsiz);
        for (int j = 0;j<MaydonTomoni; j++)
        {
            if(j< saralangan.Count)
            {
                Maydon[j][i] = saralangan[j];
            }
            else
            {
                Maydon[j][i] = 0;
            }
        }
    }
    
    int countNull = 0;
    for(int i = 0; i < MaydonTomoni; i++)
    {
        if (Maydon[MaydonTomoni - 1][i] == 0)
        {
            NulBormi[i] = 1;
            countNull++;
        }
        else
        {
            NulBormi[i] = -1;
        }
    }
    if (countNull == 0)
    {
        Console.WriteLine("O'yin tugadi!!!!!");
    }
    else
    {
        int a = MethodNull(NulBormi);
        for(int j = 0; j <MaydonTomoni; j++)
        {
            if (Maydon[j][a] == 0)
            {
                Maydon[j][a] = number.randomSonIkkiniDarajasida();
                break;
            }
        }
        Natija(MaydonTomoni, Maydon);
    }
}

void AMethod(int MaydonTomoni, params int[][] Maydon)
{
    int[] NulBormi = new int[MaydonTomoni];
    for (int i = 0; i < MaydonTomoni; i++)
    {
        List<int> nulsiz = new List<int>();
        for (int j = 0; j < MaydonTomoni; j++)
        {
            if (Maydon[i][j] != 0) nulsiz.Add(Maydon[i][j]);
        }
        List<int> saralangan = SaralabOLish(nulsiz);

        for (int j = 0; j < MaydonTomoni; j++)
        {
            if (j < saralangan.Count)
            {
                Maydon[i][j] = saralangan[j];
            }
            else
            {
                Maydon[i][j] = 0;
            }
        }
    }

    int countNull = 0;
    for (int i = 0; i < MaydonTomoni; i++)
    {
        if (Maydon[i][MaydonTomoni - 1] == 0)
        {
            NulBormi[i] = 1;
            countNull++;
        }
        else
        {
            NulBormi[i] = -1;
        }
    }
    if (countNull == 0)
    {
        Console.WriteLine("O'yin tugadi!!!!!");
    }
    else
    {
        int a = MethodNull(NulBormi);
        for (int j = 0; j < MaydonTomoni; j++)
        {
            if (Maydon[a][j] == 0)
            {
                Maydon[a][j] = number.randomSonIkkiniDarajasida();
                break;
            }
        }
        Natija(MaydonTomoni, Maydon);
    }

}
void SMethod(int MaydonTomoni, params int[][] Maydon)
{
    int[] NulBormi = new int[MaydonTomoni];
    for (int i = 0; i < MaydonTomoni; i++)
    {
        List<int> nulsiz = new List<int>();
        for (int j = MaydonTomoni-1; j >=0; j--)
        {
            if (Maydon[j][i] != 0) nulsiz.Add(Maydon[j][i]);
        }
        List<int> saralangan = SaralabOLish(nulsiz);

        for (int j = MaydonTomoni-1,z=0; j>=0; j--,z++)
        {
            if (z <saralangan.Count())
            {
                Maydon[j][i] = saralangan[z];
            }
            else
            {
                Maydon[j][i] = 0;
            }
        }
    }
    int countNull = 0;
    for (int i = MaydonTomoni-1; i >=0; i--)
    {
        if (Maydon[0][i] == 0)
        {
            NulBormi[i] = 1;
            countNull++;
        }
        else
        {
            NulBormi[i] = -1;
        }
    }
    if (countNull == 0)
    {
        Console.WriteLine("O'yin tugadi!!!!!");
    }
    else
    {
        int a = MethodNull(NulBormi);
        for (int j = MaydonTomoni-1; j >=0; j--)
        {
            if (Maydon[j][a] == 0)
            {
                Maydon[j][a] = number.randomSonIkkiniDarajasida();
                break;
            }
        }
        Natija(MaydonTomoni, Maydon);
    }
}
void DMethod(int MaydonTomoni, params int[][] Maydon)
{

    int[] NulBormi = new int[MaydonTomoni];
    for (int i = 0; i < MaydonTomoni; i++)
    {
        List<int> nulsiz = new List<int>();
        for (int j = MaydonTomoni - 1; j >= 0; j--)
        {
            if (Maydon[i][j] != 0) nulsiz.Add(Maydon[i][j]);
        }
        List<int> saralangan = SaralabOLish(nulsiz);

        for (int j = MaydonTomoni - 1, z = 0; j >= 0; j--, z++)
        {
            if (z < saralangan.Count)
            {
                Maydon[i][j] = saralangan[z];
            }
            else
            {
                Maydon[i][j] = 0;
            }
        }
    }
    int countNull = 0;
    for (int i = MaydonTomoni - 1; i >= 0; i--)
    {
        if (Maydon[i][0] == 0)
        {
            NulBormi[i] = 1;
            countNull++;
        }
        else
        {
            NulBormi[i] = -1;
        }
    }
    if (countNull == 0)
    {
        Console.WriteLine("O'yin tugadi!!!!!");
    }
    else
    {
        int a = MethodNull(NulBormi);
        for (int j = MaydonTomoni-1; j >=0; j--)
        {
            if (Maydon[a][j] == 0)
            {
                Maydon[a][j] = number.randomSonIkkiniDarajasida();
                break;
            }
        }
        Natija(MaydonTomoni, Maydon);
    }
}
List<int> nulsizLarniOlish (int MaydonTomoni,  int i,params int[][] Maydon)
{
    List<int> nulsiz = new List<int>();
    for (int j = 0; j < MaydonTomoni; j++)
    {
        if (Maydon[j][i] != 0) nulsiz.Add(Maydon[j][i]);
    }
    return nulsiz;
}
List<int> SaralabOLish(List<int> nulsiz)
{
    List<int> saralangan = new List<int>();
    for (int j = 0; j < nulsiz.Count; j++)
    {

        if (j < nulsiz.Count - 1 && nulsiz[j] == nulsiz[j + 1])
        {
            saralangan.Add(nulsiz[j] * 2);
            nulsiz[j + 1] = 0;

        }
        else
        if (nulsiz[j] != 0)
        {
            saralangan.Add(nulsiz[j]);
        }
    }
    return saralangan;
}

int MethodNull(params int[] Nuls)
{
    Random rand = new Random();
    int Num = rand.Next(Nuls.Length);
    while ((Nuls[Num] == -1))
    {
        Num = rand.Next(Nuls.Length);
    }
    //Console.WriteLine(Num);
    return Num;
}