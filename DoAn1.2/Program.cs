using DoAn1._2;
using DoAn1._2.Attribute;
using DoAn1._2.Manager;
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
            LocationManager locationManager = new LocationManager();
            AssetTypeManager assetTypeManager = new AssetTypeManager();

            // chuyển sang tiếng việt
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string choose;
            do
            {
                Console.WriteLine("\n************** Quản Lý Tài Sản Cho Công Ty *************");
                Console.WriteLine("**  1. Quản lý thông tin Tài sản                      **");
                Console.WriteLine("**  2. Quản lý thông tin Loại tài sản                 **");
                Console.WriteLine("**  3. Quản lý thông tin Vị trí                       **");
                Console.WriteLine("**  4. Tìm kiếm và theo dỗi tài sản                   **");
                Console.WriteLine("********************************************************");
                choose = Console.ReadLine();

                switch (choose)
                {

                    /// Quản lý Tài sản
                    case "1":
                        string manageChoice;
                        do
                        {
                            Console.WriteLine("\n===== Quản lý thông tin tài sản =====");
                            Console.WriteLine("**  1. Thêm tài sản                                       **");
                            Console.WriteLine("**  2. Sửa tài sản                                        **");
                            Console.WriteLine("**  3. Xóa tài sản                                        **");
                            Console.WriteLine("**  4.Hiển thị tất cả tài sản                             **");
                            Console.WriteLine("**  5.Hiển thị tất cả tài sản thuộc vị trí nhất định      **");
                            Console.WriteLine("**  6.Hiển thị tất cả tài sản thuộc một loại nhất định    **");
                            Console.WriteLine("**  7. Top 10 tài sản có giá trị cao nhất                 **");
                            Console.WriteLine("**  8. Top 10 tài sản có giá trị thấp nhất                **");
                            Console.WriteLine("**  9. Xuất file exel tất cả tài sản                      **");
                            Console.WriteLine("**  0. Quay lại                                           **");
                            Console.WriteLine("*************************************************************");

                            manageChoice = Console.ReadLine();

                            switch (manageChoice)
                            {
                                case "1":
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    
                                    Console.Write("Nhập mã tài sản: ");
                                    string id = Console.ReadLine();
                                    if (id == "exit") break;

                                    Console.Write("nhập tên tài sản: ");
                                    string name = Console.ReadLine();
                                    if(name == "exit") break;

                                    Console.Write("Nhập trạng thái tài sản: ");
                                    string status = Console.ReadLine();
                                    if(status == "exit") break;

                                    if (status.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;


                                    DateTime purchase = DateTime.MinValue; 

                                    while (true)
                                    {
                                        Console.WriteLine("Nhập ngày mua tài sản (yyyy-MM-dd):");
                                        string input = Console.ReadLine();
                                        if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

                                        if (DateTime.TryParse(input, out purchase)) break;

                                        Console.WriteLine("Ngày không hợp lệ. Vui lòng nhập lại theo định dạng (yyyy-MM-dd) hoặc nhập 'exit' để hủy.");
                                    }

                                    // Kiểm tra nếu người dùng nhập 'exit' và không có giá trị
                                    if (purchase == DateTime.MinValue)
                                    {
                                        Console.WriteLine("Thao tác đã bị hủy.");
                                        break; 
                                    }

                                    double initial = 0;
                                    while (true)
                                    {
                                        Console.Write("Nhập giá trị tài sản ban đầu: ");
                                        string input = Console.ReadLine();
                                        if (input == "exit") break;

                                        if (double.TryParse(input, out initial)) break;

                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập số hoặc nhập 'exit' để hủy.");
                                    }
                                    if (initial == 0) break;




                                    Console.WriteLine("Tất cả các thông tin về loại tài sản");
                                    assetTypeManager.DisplayAssetsType();
                                    string type;
                                    bool bool_Type = false;

                                    do
                                    {
                                        Console.Write("Nhập mã loại: ");
                                        type = Console.ReadLine();
                                        if (type == "exit") break;

                                        if (assetTypeManager.CheckType(type))
                                            bool_Type = true;
                                        else
                                            Console.WriteLine("Loại tài sản không tồn tịa, vui lòng nhập lại");

                                    } while (!bool_Type);

                                    if (type == "exit") break;

                                    Console.WriteLine("Tất cả các thông tin về vị trí của công ty");

                                    locationManager.DisplayAllLocation();
                                    bool isValid = false;
                                    int location = 0;
                                    do
                                    {
                                        Console.Write("Nhập mã vị trí: ");
                                        string input = Console.ReadLine();
                                        if (input == "exit") break;


                                        if (int.TryParse(input, out location))
                                        {
                                            Console.WriteLine($"Bạn đã nhập: {location}");

                                            if (locationManager.CheckLocation(location))
                                                isValid = true;
                                            else
                                                Console.WriteLine("Vị trí không tồn tại, vui lòng nhập lại.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Dữ liệu nhập vào không hợp lệ. Vui lòng nhập một số nguyên.");
                                        }


                                    } while (!isValid);

                                    if (location == 0) break;

                                    Assets assets = new Assets(id, name, type, purchase, initial, status,location);
                                    assetManager.AddAsset(assets);
                                    break;
                                case "2":
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    Console.WriteLine("Nhập mã tài sản mới: ");
                                    string idUpdate = Console.ReadLine();

                                    if(idUpdate == "exit") break;

                                    if (assetManager.CheckAsset(idUpdate))
                                    {
                                        Console.WriteLine("--------------------------Thông tin tài sản hiện tại--------------------------");
                                        assetManager.SearchAsset(idUpdate);
                                        Console.Write("Nhập tên tài sản mới: ");
                                        string newName = Console.ReadLine();
                                        if(newName == "exit") break;

                                        Console.Write("Nhập trạng thái tài sản mới: ");
                                        string newType = Console.ReadLine();
                                        if(newType == "exit") break;

                                        DateTime newPurchase = DateTime.MinValue; // Gán giá trị mặc định

                                        while (true)
                                        {
                                            Console.WriteLine("Nhập ngày mua tài sản (yyyy-MM-dd):");
                                            string input = Console.ReadLine();
                                            if (input == "exit") break;

                                            if (DateTime.TryParse(input, out newPurchase)) break;

                                            Console.WriteLine("Ngày không hợp lệ. Vui lòng nhập lại theo định dạng (yyyy-MM-dd) hoặc nhập 'exit' để hủy.");
                                        }

                                        double newInitialValue = 0;
                                        while (true)
                                        {
                                            Console.Write("Nhập giá trị tài sản ban đầu: ");
                                            string input = Console.ReadLine();
                                            if (input == "exit") break;

                                            if (double.TryParse(input, out newInitialValue)) break;

                                            Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập số hoặc nhập 'exit' để hủy.");
                                        }
                                        if (newInitialValue == 0) break;



                                        Console.WriteLine("Tất cả các thông tin về loại tài sản");
                                        assetTypeManager.DisplayAssetsType();
                                        string new_Type;
                                        bool bool_Type_New = false;

                                        do
                                        {
                                            Console.Write("Nhập mã loại: ");
                                            new_Type = Console.ReadLine();
                                            if(new_Type == "exit") break;
                                            if (assetTypeManager.CheckType(new_Type))
                                                bool_Type_New = true;
                                            else
                                                Console.WriteLine("Loại tài sản không tồn tịa, vui lòng nhập lại");

                                        } while (!bool_Type_New);

                                        if (new_Type == "exit") break;





                                        Console.WriteLine("Tất cả các thông tin về vị trí của công ty");

                                        locationManager.DisplayAllLocation();
                                        bool isValid_Location = false;
                                        int new_Location = 0;
                                        do
                                        {
                                            Console.Write("Nhập mã vị trí: ");
                                            string input = Console.ReadLine();
                                            if(input == "exit") break;
                                            if (int.TryParse(input, out new_Location))
                                            {
                                                Console.WriteLine($"Bạn đã nhập: {new_Location}");

                                                if (locationManager.CheckLocation(new_Location))
                                                    isValid_Location = true;
                                                else
                                                    Console.WriteLine("Vị trí không tồn tại, vui lòng nhập lại.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Dữ liệu nhập vào không hợp lệ. Vui lòng nhập một số nguyên.");
                                            }
                                        } while (!isValid_Location);

                                        if (new_Location == 0) break;

                                        assetManager.UpdateAsset(idUpdate, newName, newType, newPurchase, newInitialValue
                                            , new_Type, new_Location);


                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("Nhập mã tài sản: ");
                                    string idDelete = Console.ReadLine();
                                    if (assetManager.CheckAsset(idDelete))
                                    {
                                        Console.WriteLine("Bạn có thật sự muốn xóa dữ liệu này không (Y or N): ");
                                        string check_Yes_No = Console.ReadLine();
                                        switch(check_Yes_No)
                                        {
                                            case "Y":
                                                assetManager.DeleteAsset(idDelete);
                                                break;
                                            case "N":
                                                Console.WriteLine("Cảm ơn bạn đã không xóa tài sản!");
                                                break;
                                            default:
                                                Console.WriteLine("Dữ liệu nhập vào không đúng yêu cầu!");
                                                break;
                                        }
                                    }
                                    else
                                        Console.WriteLine("Dữ liệu không tồn tại");
                                    break;
                                case "4":
                                    Console.WriteLine("----------------------------Dưới đây là tất cả dữ liệu mà công ty đang sở hưu-----------------------------");
                                    assetManager.DisplayAllAssets();

                                    break;
                                case "5":
                                    locationManager.DisplayAllLocation();
                                    bool isValid_Location_Delete = false;
                                    int locationId = 0;
                                    do
                                    {
                                        Console.Write("Nhập mã vị trí: ");
                                        string input = Console.ReadLine();
                                        if (input == "exit") break;
                                        if (int.TryParse(input, out locationId))
                                        {
                                            Console.WriteLine($"Bạn đã nhập: {locationId}");

                                            if (locationManager.CheckLocation(locationId))
                                                isValid_Location_Delete = true;
                                            else
                                                Console.WriteLine("Vị trí không tồn tại, vui lòng nhập lại.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Dữ liệu nhập vào không hợp lệ. Vui lòng nhập một số nguyên.");
                                        }
                                    } while (!isValid_Location_Delete);

                                    if (locationId == 0) break;
                                    assetManager.PrintAssetsByLocation(locationId);
                                    break;
                                case "6":
                                    assetTypeManager.DisplayAssetsType();
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    Console.WriteLine("Nhập mã loại: ");
                                    string TypeId = Console.ReadLine();
                                    if (TypeId == "exit") break;
                                    assetManager.DisplayAssetsTypeId(TypeId);
                                    break;
                                case "7":
                                    assetManager.ExportExcelHighPrice();
                                    break;
                                case "8":
                                    assetManager.ExportExcelShortPrice();
                                    break;
                                case "9":
                                    assetManager.ExportExcelAll();
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
                            Console.WriteLine("\n************** Quản lý thông tin Loại tài sản *********");
                            Console.WriteLine("**  1. Hiển thị tất cả loại tài sản                  **");
                            Console.WriteLine("**  2. Thêm loại tài sản mới                         **");
                            Console.WriteLine("**  3. Cập nhật thông tin loại tài sản               **");
                            Console.WriteLine("**  4. Xóa loại tài sản                              **");
                            Console.WriteLine("**  0. Quay lại                                      **");
                            Console.WriteLine("*******************************************************");
                            assetTypeChoice= Console.ReadLine();

                            switch (assetTypeChoice)
                            {
                                case "1":
                                    assetTypeManager.DisplayAssetsType();
                                    break;
                                case "2":
                                    string idType;
                                    bool statusType = false;
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    do
                                    {
                                        Console.WriteLine("Mã loại tài sản: ");
                                        idType = Console.ReadLine();
                                        if(idType == "exit") break;

                                        if (assetTypeManager.CheckType(idType))
                                            Console.WriteLine("Dữ liệu này đã tồn tại, vui lòng nhập lại");
                                        else
                                            statusType = true;
                                    } while (!statusType);

                                    if (idType == "exit") break;


                                    Console.WriteLine("Tên loại tài sản: ");
                                    string nameType = Console.ReadLine();

                                    assetTypeManager.AddAssetType(idType, nameType);
                                    break;
                                case "3":
                                    string idTypeUpdate;
                                    bool statusTypeUpdate = false;
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");

                                    do
                                    {
                                        Console.WriteLine("Mã loại tài sản: ");
                                        idTypeUpdate = Console.ReadLine();
                                        if (idTypeUpdate == "exit") break;
                                        if (idTypeUpdate == "0")
                                            break;
                                        if (!assetTypeManager.CheckType(idTypeUpdate))
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                        else
                                            statusTypeUpdate = true;

                                    } while (!statusTypeUpdate);


                                    if (idTypeUpdate == "exit") break;


                                    Console.WriteLine("Tên loại tài sản: ");
                                    string nameTypeUpdate = Console.ReadLine();

                                    assetTypeManager.UpdateAssetType(idTypeUpdate, nameTypeUpdate);
                                    break;
                                case "4":
                                    string idTypeDelete;
                                    bool statusTypeDelete = false;
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    do
                                    {
                                        Console.WriteLine("Mã loại tài sản: ");
                                        idTypeDelete = Console.ReadLine();
                                        if (idTypeDelete == "exit") break;
                                        if (idTypeDelete == "0")
                                            break;
                                        if (!assetTypeManager.CheckType(idTypeDelete))
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                        else
                                            statusTypeDelete = true;

                                    } while (!statusTypeDelete);

                                    if (idTypeDelete == "exit")
                                        break;
                                    assetTypeManager.DeleteAssetType(idTypeDelete);

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
                            Console.WriteLine("\n******** Quản lý thông tin Vị trí tài sản *****");
                            Console.WriteLine("**  1. Hiển thị tất cả vị trí                **");
                            Console.WriteLine("**  2. Thêm vị trí mới                       **");
                            Console.WriteLine("**  3. Sửa vị trí                            **");
                            Console.WriteLine("**  4. Xóa vị trí                            **");
                            Console.WriteLine("**  0. Quay lại                              **");
                            Console.WriteLine("***********************************************");
                            assetLocation = Console.ReadLine();

                            switch (assetLocation)
                            {
                                case "1":
                                    locationManager.DisplayAllLocation();
                                    break;

                                case "2":
                                    int idLocationNew = 0;
                                    bool checkLocationNew = false;
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    do
                                    {
                                        Console.WriteLine("Nhập mã vị trí: ");
                                        string input = Console.ReadLine();
                                        if(input == "exit") break;

                                        if (int.TryParse(input, out idLocationNew))
                                        {
                                            idLocationNew = int.Parse(Console.ReadLine());
                                            if (idLocationNew == 0)
                                                break;
                                            if (locationManager.CheckLocation(idLocationNew))
                                                Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                            else
                                                checkLocationNew = true;
                                        } else
                                        {
                                            Console.WriteLine("Định dạng dữ liệu không chính xác");
                                        }

                                    } while (!checkLocationNew);

                                    if (idLocationNew == 0)
                                        break;

                                    Console.WriteLine("Nhập tên vị trí: ");
                                    string locationName = Console.ReadLine();
                                    if (locationName == "exit") break;

                                    Console.WriteLine("Miêu tả về vị trí: ");
                                    string description = Console.ReadLine();
                                    if(description == "exit") break;

                                    locationManager.AddLocation(idLocationNew, locationName, description);


                                    break;
                                case "3":
                                    int idLocationUpdate = 0;
                                    bool checkLocationUpdate = false;
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    do
                                    {
                                        Console.WriteLine("Nhập mã vị trí: ");
                                        string input = Console.ReadLine();
                                        if(input == "exit") break;
                                        if (int.TryParse(input, out idLocationUpdate))
                                        {
                                            if (idLocationUpdate == 0)
                                                break;
                                            if (!locationManager.CheckLocation(idLocationUpdate))
                                                Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                            else
                                                checkLocationUpdate = true;
                                        } else
                                        {
                                            Console.WriteLine("Định dạng dữ liệu không chính xác");
                                        }

                                    } while (!checkLocationUpdate);

                                    if (idLocationUpdate == 0)
                                        break;

                                    Console.WriteLine("Nhập tên vị trí: ");
                                    string locationNameNew = Console.ReadLine();
                                    if(locationNameNew == "exit") break;

                                    Console.WriteLine("Miêu tả về vị trí: ");
                                    string descriptionNew = Console.ReadLine();
                                    if(descriptionNew == "exit") break;

                                    locationManager.UpdateLocation(idLocationUpdate, locationNameNew, descriptionNew);

                                    break;
                                case "4":

                                    int idLocationDelete = 0;
                                    bool checkLocationDelete = false;
                                    Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                                    do
                                    {
                                        Console.WriteLine("Nhập mã vị trí: ");
                                        string input = Console.ReadLine();
                                        if (input == "exit") break;
                                        if(int.TryParse(input, out idLocationDelete))
                                        if (idLocationDelete == 0)
                                            break;
                                        if (!locationManager.CheckLocation(idLocationDelete))
                                            Console.WriteLine("Dữ liệu này Không tồn tại, vui lòng nhập lại");
                                        else
                                            checkLocationUpdate = true;

                                    } while (!checkLocationDelete);

                                    if (idLocationDelete == 0)
                                        break;

                                    locationManager.DeleteLocation(idLocationDelete);

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
                            Console.WriteLine("\n*********** Tìm kiếm và theo dỗi tài sản ********");
                            Console.WriteLine("**  1. Tìm kiếm tài sản                        **");
                            Console.WriteLine("**  2. Cập nhật lịch sử bảo trì                **");
                            Console.WriteLine("**  3. Xem Lịch sử bảo trì của tài sản         **");
                            Console.WriteLine("**  4. 10 tài sản có số lần bảo trì cao nhât   **");
                            Console.WriteLine("**  4. 10 tài sản có số lần bảo trì thấp nhât  **");
                            Console.WriteLine("**  0. Quay lại                                **");
                            Console.WriteLine("*************************************************");
                            Console.WriteLine("Bạn có thể nhập 'exit' bất kỳ lúc nào để hủy bỏ thao tác thêm tài sản.");
                            searchChoice = Console.ReadLine();

                            switch (searchChoice)
                            {

                                case "1":
                                    string search;
                                    do
                                    {
                                        Console.WriteLine("\n===== Tìm kiếm và theo dỗi tài sản =====");
                                        Console.WriteLine("**  1. Tìm kiếm tài sản                      **");
                                        Console.WriteLine("**  2. Tìm kiếm theo Id Tài sản              **");
                                        Console.WriteLine("**  0. Quay lại                              **");
                                        Console.WriteLine("***********************************************");
                                        search = Console.ReadLine();

                                        switch (search )
                                        {
                                            case "1":
                                                Console.WriteLine("Nhập tên Tài sản: ");
                                                string name = Console.ReadLine();
                                                if (name == "exit") break;
                                                assetManager.SearchAssetName(name);
                                                break;
                                            case "2":
                                                Console.WriteLine("Nhập mã tài sản: ");
                                                string id = Console.ReadLine();
                                                if (id == "exit") break;
                                                assetManager.SearchAsset(id);
                                                break;
                                            default:
                                                Console.WriteLine("Lựa chọn không hợp lệ");
                                                break;
                                        }
                                    } while (search != "0");
                                    break;
                                case "2":
                                    Console.WriteLine("Nhập mã tài sản đã bảo trì: ");
                                    string idMaintenance = Console.ReadLine();
                                    if(idMaintenance == "exit") break;

                                    DateTime maintenanceDate = DateTime.MinValue; 

                                    while (true)
                                    {
                                        Console.WriteLine("Nhập ngày mua tài sản (yyyy-MM-dd):");
                                        string input = Console.ReadLine();
                                        if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

                                        if (DateTime.TryParse(input, out maintenanceDate)) break;

                                        Console.WriteLine("Ngày không hợp lệ. Vui lòng nhập lại theo định dạng (yyyy-MM-dd) hoặc nhập 'exit' để hủy.");
                                    }

                                    // Kiểm tra nếu người dùng nhập 'exit' và không có giá trị
                                    if (maintenanceDate == DateTime.MinValue)
                                    {
                                        Console.WriteLine("Thao tác đã bị hủy.");
                                        break; 
                                    }

                                    break;
                                case"3":
                                    Console.WriteLine("Nhập mã tài sản đã bảo trì: ");
                                    string idMaintenanceShow = Console.ReadLine();
                                    if(idMaintenanceShow == "exit") break;
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


