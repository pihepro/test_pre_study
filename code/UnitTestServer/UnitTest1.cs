using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThriftServer;
using storage;

namespace UnitTestServer
{
    [TestClass]
    public class UnitTest1
    {

        StorageServiceHandler _handler;

        [TestInitialize]
        public void InitializeSomething()
        {
           _handler = new StorageServiceHandler();
          _handler.ClearStorage();
        }

        [TestCleanup]
        public void CleanupSomething()
        {

        }

        [TestMethod]
        public void AddStoragePointItem()
        {
           // Assert.AreEqual("Moi", "Moi");
          var storagepoint = new StoragePoint { StorageId = 0, Name = "Storage Point 1", Description = "Description 1" };
          Assert.IsTrue(_handler.AddStoragePoint(storagepoint), "Storage point add failed");
         // Assert.isFalse(_handler.AddStoragePoint(storagepoint), "Storage point add duplicate item failed");
        }
    }
}
