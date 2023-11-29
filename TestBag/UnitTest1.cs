using Assignment1;
namespace TestBag;

[TestClass]
public class UnitTest1
{
    Bag bag = new Bag();
    int initialLength = 0;
    

    [TestMethod]
    public void TestInsert_FirstElement()
    {
       
        bag.Insert(4);
        Assert.AreEqual(initialLength + 1, bag._seq.Count);
    }

    [TestMethod]
    public void TestInsert_SameElement()
    {
        bag.Insert(4);
        bag.Insert(4);
        int frequency = 2;
        int actual = 0;
        bag.Insert(4);

        for (int i = 0; i < bag._seq.Count; i++)
        {
            if (bag._seq[i].element == 4)
            {
                actual = bag._seq[i].frequency;
            }
        }

        Assert.AreEqual(frequency + 1, actual);
    }

    [TestMethod]
    public void TestInsert_DifferentElement()
    {
        bag.Insert(3);
        bag.Insert(3);
        
        bag.Insert(2);
        int original = 2;

        bag.Insert(8);
     

        Assert.AreEqual(original + 1, bag._seq.Count);
    }

    [TestMethod]
    public void TestRemove_EmptyBag()
    {
        Assert.ThrowsException<Bag.EmptyBagException>
            (
                () => bag.Remove(4)
            );
    }

    [TestMethod]
    public void TestRemove_NotFoundInBag()
    {
        bag.Insert(4);
        bag.Insert(7);

        Assert.ThrowsException<Bag.ElementNotFoundException>
            (
                () => bag.Remove(3)
            );
    }

    [TestMethod]
    public void TestRemove_ElementInBag()
    {
        bag.Insert(5);
        bag.Insert(5);
        bag.Insert(7);

        int original = 2;
        bag.Remove(7);

        Assert.AreEqual(original - 1, bag._seq.Count);
    }

    [TestMethod]
    public void TestFrequency_EmptyBag()
    {
        Assert.ThrowsException<Bag.EmptyBagException>
           (
               () => bag.Frequency(4)
           );
    }

    [TestMethod]
    public void TestFrequency_NotFoundInBag()
    {
        bag.Insert(4);
        bag.Insert(7);

        Assert.ThrowsException<Bag.ElementNotFoundException>
            (
                () => bag.Frequency(3)
            );

    }

    [TestMethod]
    public void TestFrequency_ElementInBag()
    {
        bag.Insert(5);
        bag.Insert(5);
        bag.Insert(7);

        int original = 2;
        bag.Insert(5);

        Assert.AreEqual(original + 1, bag.Frequency(5));
    }

    [TestMethod]
    public void TestMostFreq_EmptyBag()
    {
        Assert.ThrowsException<Bag.EmptyBagException>
           (
               () => bag.MostFrequent()
           ) ;
    }

    [TestMethod]
    public void TestMostFreq_OneElement()
    {
        bag.Insert(5);
        int element = 5;

        Assert.AreEqual(element, bag.MostFrequent());
    }

    [TestMethod]
    public void TestMostFreq_ElementInBag_UpdateTheValue()
    {
        bag.Insert(1);
        bag.Insert(1);
        bag.Insert(2);
        bag.Insert(2);
        bag.Insert(2);
        bag.Remove(2);
        bag.Remove(2);
        int result = 1;

        Assert.AreEqual(result, bag.MostFrequent());
    }

    [TestMethod]
    public void TestMostFreq_ElementInBag()
    {
        bag.Insert(1);
        bag.Insert(2);
        bag.Insert(2);
        bag.Insert(3);
        bag.Insert(3);
        bag.Insert(3);
        int result = 3;

        Assert.AreEqual(result, bag.MostFrequent());
    }

    [TestMethod]
    public void TestPrint_EmptyBag()
    {
        Assert.ThrowsException<Bag.EmptyBagException>
          (
              () => bag.MostFrequent()
          );
    }


}
