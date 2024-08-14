using System;

// Menerapkan Prinsip OOP

/* Panduan 
Abstraction Modeling the relevant attributes and interactions of entities as classes to define an abstract representation of a system.
Encapsulation Hiding the internal state and functionality of an object and only allowing access through a public set of functions.
Inheritance Ability to create new abstractions based on existing abstractions.
Polymorphism Ability to implement inherited properties or methods in different ways across multiple abstractions. 
*/



// membuat Abtraksi
abstract class Simulator
{
    //implementasi kelas turunan
    public abstract void Run();
}

// membuat enkaptulasi
class Tanaman
{
    public int Tinggi { get; private set; }
    public int LevelAir { get; private set; }
    public int SinarMatahari { get; private set; }
    public int Hari { get; private set; }

    //menerapkan nilai konstan Pertumbuhan
    private const int Pertumbuhan = 5;

    //fungsi untuk menambah air
    public void TambahAir(int unit)
    {
        if (unit >= 1 && unit <= 10)
        {
            LevelAir += unit;
            Hari++;
            Console.WriteLine($"Anda menambahkan {unit} unit air");
        }
        else
        {
            Console.WriteLine($"Jumlah {unit} tidak benar. harus antara 1-10");
        }
    }
    //fungsi untuk menambah sinar matahari
    public void TambahSinar(int unit)
    {
        if (unit >= 1 && unit <= 10)
        {
            LevelAir += unit;
            Hari++;
            Console.WriteLine($"Anda menambahkan {unit} unit sinar matahari");
        }
        else
        {
            Console.WriteLine($"Jumlah {unit} tidak benar. harus antara 1-10");
        }
    }
  
   
    // fungsi untuk memeriksa status tanaman
    public void CekStatusTanaman()
    {
        if (LevelAir > Pertumbuhan && SinarMatahari > Pertumbuhan)
        {
            Tinggi += 2;
            LevelAir -= 5;
            Console.WriteLine("Tanaman tumbuh lebih tinggi!");
        }else if(LevelAir <= 0 || SinarMatahari <= 0)
        {
            Console.WriteLine("Tanaman mati karena kurang perawatan.");
            ResetTanaman();
        }
        else
        {
            Console.WriteLine("Tanaman tidak tumbuh, tambahkan lebih banyak air dan sinar matahari.");
        }
    }
    // fungsi untuk menampilkan status tanaman
    public void TampilkanStatusTanaman()
    {
        Console.WriteLine($"Tinggi Tanaman: {Tinggi}, Level Air: {LevelAir}, Sinar Matahari: {SinarMatahari}, Hari: {Hari}");
    }

    // fungsi untuk mereset status tanaman
    private void ResetTanaman()
    {
        Tinggi = LevelAir = SinarMatahari = Hari = 0;
    }
}

// Kelas Simulator Tanaman
class SimulatorTanaman : Simulator
{
    private readonly Tanaman _tanaman = new();
    // fungsi menjalankan simulasi
    public override void Run()
    {
        int Pilihan;
        do
        {
            Console.WriteLine("=== Simulator Pertumbuhan Tanaman ===\n" +
                "1. Tambah Air\n" +
                "2. Tambah Sinar Matahari\n" +
                "3. Lihat Status Tanaman\n" +
                "4. Cek Pertumbuhan Tanaman\n" +
                "5. Keluar\n" +
                "Pilih opsi (1-5)");
            Pilihan = int.TryParse(Console.ReadLine(), out int hasil) ? hasil : 0;

            switch (Pilihan)
            {
                case 1:
                    _tanaman.TambahAir(InputNilai("air"));
                    break;
                case 2:
                    _tanaman.TambahSinar(InputNilai("sinar matahari"));
                    break;
                case 3:
                    _tanaman.TampilkanStatusTanaman();
                    break;
                case 4:
                    _tanaman.CekStatusTanaman();
                    break;
                case 5:
                    Console.WriteLine("Keluar dari program...");
                    break;
                default:
                    Console.WriteLine("Opsi tidak benar");
                    break;
            }
        } while (Pilihan != 5);

    }
    private int InputNilai(String type)
    {
        Console.Write($"Masukkan jumlah {type} yang ditambahkan (1-10): ");
        return
            int.TryParse(Console.ReadLine(), out int nilai) ? nilai : 0;
    }
}
// fungsi untuk menerima inputan pengguna

class Program
{
        static void Main(string[] args)
        {
            new SimulatorTanaman().Run();
        }
   }