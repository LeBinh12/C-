using DoAn1._2;
using DoAn1._2.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AssetManager assetManager= new AssetManager();

            // chuyển sang tiếng việt
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string choose;
            do
            {
                Console.WriteLine("\n===== Quản Lý Tài Sản Cho Công Ty =====");
                Console.WriteLine("1. Quản lý thông tin Tài sản");
                Console.WriteLine("2. Quản lý thông tin Loại tài sản");
                Console.WriteLine("3. Quản lý thông tin Vị trí");
                Console.WriteLine("4. Tìm kiếm và theo dỗi tài sản");

                choose = Console.ReadLine();

                switch (choose)
                {

                    /// Quản lý Tài sản
                    case "1":
                        string manageChoice;
                        do
                        {
                            Console.WriteLine("\n===== Quản lý thông tin tài sản =====");
                            Console.WriteLine("1. Thêm tài sản");
                            Console.WriteLine("2. Sửa tài sản");
                            Console.WriteLine("3. Xóa tài sản");
                            Console.WriteLine("4.Hiển thị tất cả tài sản");
                            Console.WriteLine("5.Hiển thị tất cả tài sản thuộc vị trí nhất định");
                            Console.WriteLine("6.Hiển thị tất cả tài sản thuộc một loại nhất định");
                            Console.WriteLine("0. Quay lại");

                            manageChoice = Console.ReadLine();

                            switch (manageChoice)
                            {
                                case "1":
                                    Console.Write("Enter Asset ID: ");
                                    string id = Console.ReadLine();
                                    Console.Write("Enter Name: ");
                                    string name = Console.ReadLine();
                                    Console.Write("Enter tyoe: ");
                                    string type = Console.ReadLine();
                                    Console.WriteLine("Nhập ngày mua tài sản (yyyy-MM-dd):");
                                    DateTime purchase;
                                    while (!DateTime.TryParse(Console.ReadLine(), out purchase))
                                    {
                                        Console.WriteLine("Ngày không hợp lệ. Vui lòng nhập lại theo định dạng (yyyy-MM-dd):");
                                    }

                                    Console.Write("Enter Initial: ");
                                    double initial = double.Parse(Console.ReadLine());
                                    Console.Write("Enter Maintenance: ");
                                    string maintenance = Console.ReadLine();
                                    string status;
                                    bool boolStatus = false;

                                    do
                                    {
                                        Console.Write("Enter Status: ");
                                        status = Console.ReadLine();

                                        if (assetManager.CheckType(status))
                                            boolStatus = true;
                                        else
                                            Console.WriteLine("Loại tài sản không tồn tịa, vui lòng nhập lại");

                                    } while (!boolStatus);






                                    assetManager.DisplayAllLocation();
                                    int location;
                                    bool isValid = false;

                                    do
                                    {
                                        Console.Write("Enter Location: ");
                                        location = int.Parse(Console.ReadLine());
                                        if(assetManager.CheckLocation(location))
                                            isValid= true;
                                        else
                                           Console.WriteLine("Vị trí không tồn tại, vui lòng nhập lại.");

                                    } while (!isValid);
                                    Assets assets = new Assets(id, name, type, purchase, initial, maintenance, status,location);
                                    assetManager.AddAsset(assets);
                                    break;
                                case "2":
                                    Console.WriteLine("Nhập mã tài sản: ");
                                    string idUpdate = Console.ReadLine();
                                    if (assetManager.CheckAsset(idUpdate))
                                    {
                                        Console.Write("Enter Name: ");
                                        string newName = Console.ReadLine();
                                        Console.Write("Enter tyoe: ");
                                        string newType = Console.ReadLine();
                                        Console.WriteLine("Nhập ngày mua tài sản (yyyy-MM-dd):");
                                        DateTime newPurchase;
                                        while (!DateTime.TryParse(Console.ReadLine(), out newPurchase))
                                        {
                                            Console.WriteLine("Ngày không hợp lệ. Vui lòng nhập lại theo định dạng (yyyy-MM-dd):");
                                        }

                                        Console.Write("Enter Initial: ");
                                        double newInitialValue = double.Parse(Console.ReadLine());
                                        Console.Write("Enter Maintenance: ");
                                        string newMaintenance = Console.ReadLine();
                                        Console.Write("Enter Status: ");
                                        string newStatus = Console.ReadLine();
                                        assetManager.DisplayAllLocation();
                                        Console.Write("Enter Location: ");
                                        int newLocationId = int.Parse(Console.ReadLine());

                                        assetManager.UpdateAsset(idUpdate, newName, newType, newPurchase, newInitialValue,
                                            newMaintenance, newStatus, newLocationId);
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("Nhập mã tài sản: ");
                                    string idDelete = Console.ReadLine();
                                    if(assetManager.CheckAsset(idDelete))
                                        assetManager.DeleteAsset(idDelete);
                                    else
                                        Console.WriteLine("Dữ liệu không tồn tại");
                                    break;
                                case "4":
                                    assetManager.DisplayAllAssets();

                                    break;
                                case "5":
                                    assetManager.DisplayAllLocation();
                                    Console.WriteLine("Nhập mã vị trí: ");
                                    int locationId = int.Parse(Console.ReadLine());
                                    assetManager.PrintAssetsByLocation(locationId);
                                    break;
                                case "6":
                                    assetManager.DisplayAssetsType();
                                    Console.WriteLine("Nhập mã loại: ");
                                    string TypeId = Console.ReadLine();
                                    assetManager.DisplayAssetsTypeId(TypeId);
                                    break;
                                case "0":
                                    break;
                                default:
                                    Console.WriteLine("Lựa chọn không hợp lệ.");
                                    break;
                            }

                        } while (manageChoice != "0");
                        break;


                        /////Quản lý Loại tài sản
                    case "2":
                        string assetTypeChoice;
                        do
                        {
                            Console.WriteLine("\n===== Quản lý thông tin Loại tài sản =====");
                            Console.WriteLine("1. Thêm loại tài sản mới");
                            Console.WriteLine("2. Cập nhật thông tin loại tài sản");
                            Console.WriteLine("3. Xóa loại tài sản");
                            Console.WriteLine("0. Quay lại");

                            assetTypeChoice= Console.ReadLine();

                            switch (assetTypeChoice)
                            {
                                case "1":
                                    string idType;
                                    bool statusType = false;

                                    do
                                    {
                                        Console.WriteLine("Mã loại tài sản: ");
                                        idType = Console.ReadLine();
                                        if (assetManager.CheckType(idType))
                                            Console.WriteLine("Dữ liệu này đã tồn tại, vui lòng nhập lại");
                                        else
                                            statusType = true;
                                    } while (!statusType);

                                    Console.WriteLine("Tên loại tài sản: ");
                                    string nameType = Console.ReadLine();

                                    assetManager.AddAssetType(idType, nameType);
                                    break;
                                case "2":
                                    string idTypeUpdate;
                                    bool statusTypeUpdate = false;

                                    do
                                    {
                                        Console.WriteLine("Mã loại tài sản: ");
                                        idTypeUpdate = Console.ReadLine();
                                        if (idTypeUpdate == "0")
                                            break;
                                        if (!assetManager.CheckType(idTypeUpdate))
                                        {
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                            Console.WriteLine("Bạn có thể nhập số 0 để quay lại!!");
                                        }
                                        else
                                            statusTypeUpdate = true;

                                    } while (!statusTypeUpdate);

                                    if (idTypeUpdate == "0")
                                        break;

                                    Console.WriteLine("Tên loại tài sản: ");
                                    string nameTypeUpdate = Console.ReadLine();

                                    assetManager.UpdateAssetType(idTypeUpdate, nameTypeUpdate);
                                    break;
                                case "3":
                                    string idTypeDelete;
                                    bool statusTypeDelete = false;

                                    do
                                    {
                                        Console.WriteLine("Mã loại tài sản: ");
                                        idTypeDelete = Console.ReadLine();
                                        if (idTypeDelete == "0")
                                            break;
                                        if (!assetManager.CheckType(idTypeDelete))
                                        {
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                            Console.WriteLine("Bạn có thể nhập số 0 để quay lại!!");
                                        } else
                                            statusTypeDelete = true;

                                    } while (!statusTypeDelete);

                                    if (idTypeDelete == "0")
                                        break;
                                    assetManager.DeleteAssetType(idTypeDelete);

                                    break;
                                case "0":
                                    break;
                                default:
                                    Console.WriteLine("Lỗi cú pháp");
                                    break;

                            }
                            
                        } while (assetTypeChoice != "0");


                        break;


                        /// Quản lý Vị trí tài sản
                    case "3":

                        string assetLocation;
                        do
                        {
                            Console.WriteLine("\n===== Quản lý thông tin Vị trí tài sản =====");
                            Console.WriteLine("1. Thêm vị trí");
                            Console.WriteLine("2. Sửa vị trí");
                            Console.WriteLine("3. Xóa vị trí");
                            Console.WriteLine("0. Quay lại");

                            assetLocation = Console.ReadLine();

                            switch (assetLocation)
                            {
                                case "1":
                                    int idLocationNew;
                                    bool checkLocationNew = false;

                                    do
                                    {
                                        Console.WriteLine("Nhập mã vị trí: ");
                                        idLocationNew = int.Parse(Console.ReadLine());
                                        if (idLocationNew == 0)
                                            break;
                                        if (assetManager.CheckLocation(idLocationNew))
                                        {
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                            Console.WriteLine("Bạn có thể nhập số 0 để quay lại!!");
                                        }
                                        else
                                            checkLocationNew = true;

                                    } while (!checkLocationNew);

                                    if (idLocationNew == 0)
                                        break;

                                    Console.WriteLine("Nhập tên vị trí: ");
                                    string locationName = Console.ReadLine();
                                    Console.WriteLine("Miêu tả về vị trí: ");
                                    string description = Console.ReadLine();

                                    assetManager.AddLocation(idLocationNew, locationName, description);


                                    break;
                                case "2":
                                    int idLocationUpdate;
                                    bool checkLocationUpdate = false;

                                    do
                                    {
                                        Console.WriteLine("Nhập mã vị trí: ");
                                        idLocationUpdate = int.Parse(Console.ReadLine());
                                        if (idLocationUpdate == 0)
                                            break;
                                        if (!assetManager.CheckLocation(idLocationUpdate))
                                        {
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                            Console.WriteLine("Bạn có thể nhập số 0 để quay lại!!");
                                        }
                                        else
                                            checkLocationUpdate = true;

                                    } while (!checkLocationUpdate);

                                    if (idLocationUpdate == 0)
                                        break;

                                    Console.WriteLine("Nhập tên vị trí: ");
                                    string locationNameNew = Console.ReadLine();
                                    Console.WriteLine("Miêu tả về vị trí: ");
                                    string descriptionNew = Console.ReadLine();

                                    assetManager.UpdateLocation(idLocationUpdate, locationNameNew, descriptionNew);

                                    break;
                                case "3":

                                    int idLocationDelete;
                                    bool checkLocationDelete = false;

                                    do
                                    {
                                        Console.WriteLine("Nhập mã vị trí: ");
                                        idLocationDelete = int.Parse(Console.ReadLine());
                                        if (idLocationDelete == 0)
                                            break;
                                        if (!assetManager.CheckLocation(idLocationDelete))
                                        {
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                            Console.WriteLine("Bạn có thể nhập số 0 để quay lại!!");
                                        }
                                        else
                                            checkLocationUpdate = true;

                                    } while (!checkLocationDelete);

                                    if (idLocationDelete == 0)
                                        break;

                                    assetManager.DeleteLocation(idLocationDelete);

                                    break;
                                case "0":
                                    break;
                            }
                        } while (assetLocation != "0");

                        break;
                    /// Quản lý Tìm kiếm...
                    case "4":
                        string searchChoice;
                        
                        do
                        {
                            Console.WriteLine("\n===== Tìm kiếm và theo dỗi tài sản =====");
                            Console.WriteLine("1. Tìm kiếm theo tên Tài sản");
                            Console.WriteLine("2. Tìm kiếm theo Id Tài sản");
                            Console.WriteLine("3. Cập nhật lịch sử bảo trì");
                            Console.WriteLine("4. Lịch sử bảo trì của tài sản");
                            Console.WriteLine("0. Quay lại");
                            searchChoice = Console.ReadLine();

                            switch (searchChoice)
                            {
                                case "1":
                                    Console.WriteLine("Nhập tên Tài sản: ");
                                    string name = Console.ReadLine();
                                    assetManager.SearchAssetName(name);
                                    break;
                                case "2":
                                    Console.WriteLine("Nhập mã tài sản: ");
                                    string id = Console.ReadLine();
                                    assetManager.SearchAsset(id);
                                    break;
                                case "3":
                                    Console.WriteLine("Nhập mã tài sản đã bảo trì: ");
                                    string idMaintenance = Console.ReadLine();
                                    Console.WriteLine("Nhập ngày bảo trì (yyyy-MM-dd): ");
                                    DateTime maintenanceDate = DateTime.Parse(Console.ReadLine());
                                    assetManager.AddMaintenance(idMaintenance, maintenanceDate);
                                    break;
                                case"4":
                                    Console.WriteLine("Nhập mã tài sản đã bảo trì: ");
                                    string idMaintenanceShow = Console.ReadLine();
                                    assetManager.ShowMaintenanceHistory(idMaintenanceShow);
                                    break;
                                default:
                                    Console.WriteLine("Lựa chọn không hợp lệ.");
                                    break;
                            }

                        } while (searchChoice != "0");
                        break;
                    default:
                        Console.WriteLine("Lỗi cú pháp");
                        break;
                }


            } while (choose != "0");
        }
    }
}


