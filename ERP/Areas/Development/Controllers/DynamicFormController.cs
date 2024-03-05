using Business.Entities.DevelopmentArea.DynamicFormM;
using Business.Interface.DevelopmentArea.IDynamicFormService;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using ERP.Controllers;
using ERP.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Development.Controllers
{
    [Area("Development"), Authorize]
    public class DynamicFormController : SettingsController
    {
        private readonly IDynamicFormService _dynamicFormService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly string linkFolderPath;
        private readonly string modelNameSpaceText;
        private readonly string _interfacePath;
        private readonly string _servicePath;
        private readonly string _interfaceTemplatePath;
        private readonly string _serviceTemplatePath;
        private readonly string _controllerTemplatePath;
        private readonly string _indexViewTemplatePath;
        private readonly string _addUpdateViewTemplatePath;
        private readonly string _controllerPath;
        private readonly string _areaPath;
        private readonly string _viewImportsPath;
        private readonly string _viewStartPath;
        private readonly string _dependencyFile;
        private readonly string _commonExtentionFilePath;
        private readonly string _commonExtentionServiceFilePath;
        private readonly string _commonExtentionInterfaceFilePath;
        private readonly string _commonExtentionModelFilePath;
        public DynamicFormController(IDynamicFormService dynamicFormService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _dynamicFormService = dynamicFormService;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            linkFolderPath = _configuration.GetSection("AutoGenerateFiles")["AutoGenerateModelPath"];
            modelNameSpaceText = _configuration.GetSection("AutoGenerateFiles")["ModelNameSpaceText"];
            _interfacePath = _configuration.GetSection("AutoGenerateFiles")["AutoGenerateInterface"];
            _servicePath = _configuration.GetSection("AutoGenerateFiles")["AutoGenerateService"];
            _interfaceTemplatePath = _configuration.GetSection("AutoGenerateFiles")["InterfaceTemplatePath"];
            _serviceTemplatePath = _configuration.GetSection("AutoGenerateFiles")["ServiceTemplatePath"];
            _controllerTemplatePath = _configuration.GetSection("AutoGenerateFiles")["ControllerTemplatePath"];
            _indexViewTemplatePath = _configuration.GetSection("AutoGenerateFiles")["IndexViewTemplatePath"];
            _addUpdateViewTemplatePath = _configuration.GetSection("AutoGenerateFiles")["AddUpdateViewTemplatePath"];
            _controllerPath = _configuration.GetSection("AutoGenerateFiles")["AutoGenerateController"];
            _areaPath = _configuration.GetSection("AutoGenerateFiles")["AreaPath"];
            _viewImportsPath = _configuration.GetSection("AutoGenerateFiles")["ViewImportsPath"];
            _viewStartPath = _configuration.GetSection("AutoGenerateFiles")["ViewStartPath"];
            _dependencyFile = _configuration.GetSection("AutoGenerateFiles")["DependencyFile"];
            _commonExtentionFilePath = _configuration.GetSection("AutoGenerateFiles")["CommonExtentionFilePath"];
            _commonExtentionServiceFilePath = _configuration.GetSection("AutoGenerateFiles")["CommonExtensionServiceFilePath"];
            _commonExtentionInterfaceFilePath = _configuration.GetSection("AutoGenerateFiles")["CommonExtensionInterfaceFilePath"];
            _commonExtentionModelFilePath = _configuration.GetSection("AutoGenerateFiles")["CommonExtensionModelFilePath"];

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Dropdown for add update table.
        public JsonResult GetAllDataTypes()
        {
            try
            {
                var allDataTypes = _dynamicFormService.GetAllDataTypes().Select(x => new { DataTypeText = x.DataTypeText, SQLSrvDataType = x.SQLSrvDataType }).ToList();
                return Json(allDataTypes);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public JsonResult GetAllDatabaseTables()
        {
            try
            {
                var allTables = _dynamicFormService.GetAllDatabaseTables().Select(x => new { TableName = x.TableName }).ToList();
                return Json(allTables);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Dropdown for add update table.

        #region Add update table.
        [HttpPost]
        public async Task<IActionResult> AddUpdateTable(string tableData, string tableName, string tableDescription, string selectedPackage)
        {
            try
            {   
                string rootpath = _webHostEnvironment.ContentRootPath;
                string Servicerootpath = _webHostEnvironment.ContentRootPath.Remove(rootpath.Length - 4);
             
                selectedPackage = selectedPackage.Replace("Select Package", "Admin").Replace(" ", "").Replace("&", "");

                DataTable dataTable = new DataTable();
                List<TableData> listTableData = new List<TableData>();

                if (!string.IsNullOrEmpty(tableData) && !string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(tableDescription))
                {
                    listTableData = JsonConvert.DeserializeObject<List<TableData>>(tableData);
                    int Srchable = 0;
                     
                    #region Creating DataTable.

                    dataTable.Columns.Clear();
                    dataTable.Columns.Add(new DataColumn("ColSrNo", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("UserTableName", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("ColumnName", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("ColumnType", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("ColumnSize", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("ColumnIsNull", typeof(bool)));
                    dataTable.Columns.Add(new DataColumn("ColumnIsForeignKey", typeof(bool)));
                    dataTable.Columns.Add(new DataColumn("ColumnFKMapToTable", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("ColumnIsDefault", typeof(bool)));
                    dataTable.Columns.Add(new DataColumn("ColumnDefaultValue", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("ColumnIsSearchable", typeof(bool)));

                    int i = 1;
                    foreach (var item in listTableData)
                    {
                        DataRow dataRow = dataTable.NewRow();

                        dataRow["ColSrNo"] = i;
                        dataRow["UserTableName"] = tableName;
                        dataRow["ColumnName"] = item.ColumnName;
                        dataRow["ColumnSize"] = item.Size;
                        dataRow["ColumnIsNull"] = item.IsMandatory;
                        dataRow["ColumnType"] = item.Datatype;

                        dataRow["ColumnIsForeignKey"] = item.IsReference;
                        dataRow["ColumnFKMapToTable"] = "";
                        if (item.IsReference == true)
                        {
                            dataRow["ColumnFKMapToTable"] = item.ReferenceTable;
                            dataRow["ColumnName"] = item.ReferenceTable + "ID";
                        }
                        dataRow["ColumnIsDefault"] = item.IsDefault;
                        dataRow["ColumnDefaultValue"] = item.DefaultValue;
                        if (item.Datatype == "Varchar")
                        {
                            if (item.IsSearchable == true)
                            {
                                dataRow["ColumnIsSearchable"] = item.IsSearchable;
                                Srchable++;
                            }
                        }
                        else
                        {
                            dataRow["ColumnIsSearchable"] = false;
                        }
                        dataTable.Rows.Add(dataRow);
                        i++;
                    }

                    #endregion Creating DataTable.
                     
                    bool result =  false;
                    if (Srchable >= 1)
                    {
                        result = await _dynamicFormService.AddUpdateTable(dataTable, tableDescription, DISPLAYUSERNAME);
                    }
                    else
                    {
                        return Json(new { status = false, message = "Please select atleast one searchable column." });
                    }
                    if (result)
                    {


                        #region Creating model.
                        string path1 = Servicerootpath + linkFolderPath + selectedPackage + "\\" + tableName + "Model";
                        if (!Directory.Exists(path1))
                            Directory.CreateDirectory(path1);

                        string modelProperties = _dynamicFormService.GenerateModelProperties(tableName).Result.Replace("bool?", "bool").Replace("IsActive { get; set; }", "IsActive { get; set; } = true;");     // model generate according to table and from database.


                        if (Directory.Exists(path1))
                        {
                            path1 += "\\" + tableName + ".cs";
                            using (var fileStream = new FileStream(path1, FileMode.Create, FileAccess.ReadWrite))
                            {
                                string testModel = modelNameSpaceText.Replace("$ModuleName$", selectedPackage).Replace("$TableName$", tableName) + modelProperties + "\r\n}";
                                if (!Directory.Exists(path1))
                                {
                                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(modelNameSpaceText.Replace("$ModuleName$", selectedPackage).Replace("$TableName$", tableName) + modelProperties + "\r\n}");
                                    // Write the content to the file
                                    fileStream.Write(bytes, 0, bytes.Length);
                                }
                            }
                        }
                        #endregion Creating model.

                        #region Creating interface.
                        string interfacePath = Servicerootpath + _interfacePath + selectedPackage + "\\" + "I" + tableName;
                        if (!Directory.Exists(interfacePath))
                            Directory.CreateDirectory(interfacePath);

                        if (Directory.Exists(interfacePath))
                        {
                            interfacePath += "\\" + tableName + "Interface.cs";
                            using (StreamReader streamReader = new StreamReader(rootpath + _interfaceTemplatePath))
                            {
                                string fileContent = streamReader.ReadToEnd();

                                string newContent = fileContent.Replace("$TableName$", tableName).Replace("$ModuleName$", selectedPackage);

                                using (StreamWriter sw = new StreamWriter(interfacePath))
                                {
                                    sw.Write(newContent);
                                }
                            }
                        }
                        #endregion Creating interface.

                        #region Creating service.

                        string servicePath = Servicerootpath + _servicePath + selectedPackage + "\\" + "S" + tableName;
                        if (!Directory.Exists(servicePath))
                            Directory.CreateDirectory(servicePath);

                        if (Directory.Exists(servicePath))
                        {
                            servicePath += "\\" + tableName + "Service.cs";

                            List<string> sqlParams = _dynamicFormService.GetSqlParams(tableName).Result;
                            string test = Convert.ToString(sqlParams[0]);
                            using (StreamReader streamReader = new StreamReader(rootpath + _serviceTemplatePath))
                            {
                                string fileContent = streamReader.ReadToEnd();

                                string newContent = fileContent.Replace("$TableName$",  tableName).Replace("$ModuleName$", selectedPackage).Replace("$PackageName$", selectedPackage).Replace("$SQLInputParameter$", Convert.ToString(sqlParams[0]));

                                using (StreamWriter sw = new StreamWriter(servicePath))
                                {
                                    sw.Write(newContent);
                                }
                            }
                        }
                        #endregion Creating service.



                        #region Creating Area.

                        if (Directory.Exists(rootpath + _areaPath))
                        {
                            string areaPath = rootpath + _areaPath + selectedPackage + "\\";
                            if (!Directory.Exists(areaPath))
                                Directory.CreateDirectory(areaPath);

                            if (Directory.Exists(areaPath))
                            {
 
                                #region Creating ViewImportStarts.

                                string fullImportFilePath = areaPath + "_ViewImports.cshtml";
                                string fillStartFilePath = areaPath + "_ViewStart.cshtml";

                                FileInfo impostFileInfo = new FileInfo(fullImportFilePath);
                                FileInfo startFileInfo = new FileInfo(fillStartFilePath);

                                if (!impostFileInfo.Exists)
                                {
                                    using (FileStream sourceStream = new FileStream(rootpath + _viewImportsPath, FileMode.Open))
                                    {
                                        using (FileStream destinationStream = new FileStream(fullImportFilePath, FileMode.Create))
                                        {
                                            sourceStream.CopyTo(destinationStream);
                                        }
                                    }
                                }
                                if (!startFileInfo.Exists)
                                {
                                    using (FileStream sourceStream = new FileStream(rootpath + _viewStartPath, FileMode.Open))
                                    {
                                        using (FileStream destinationStream = new FileStream(fillStartFilePath, FileMode.Create))
                                        {
                                            sourceStream.CopyTo(destinationStream);
                                        }
                                    }
                                }

                                #endregion Creating ViewImportStarts.
                                
                                #region Creating Controller.

                                string controllerpath = areaPath + "Controllers";

                                if (!Directory.Exists(controllerpath))
                                    Directory.CreateDirectory(controllerpath);

                                if (Directory.Exists(controllerpath))
                                {
                                    // create controller here   
                                    string pathWithControllerName = controllerpath + "\\" + tableName + "Controller.cs";
                                    FileInfo fileInfo = new FileInfo(pathWithControllerName);
                                    if (!fileInfo.Exists)
                                    {
                                        List<string> sqlParams = _dynamicFormService.GetSqlParams(tableName).Result;
                                        string test = Convert.ToString(sqlParams[1]);
                                        using (StreamReader streamReader = new StreamReader(rootpath + _controllerTemplatePath))
                                        {
                                            string fileContent = streamReader.ReadToEnd();

                                            string newContent = fileContent.Replace("$TableName$", tableName).Replace("$ModuleName$", selectedPackage).Replace("$ShowColumn$", Convert.ToString(sqlParams[1])).Replace("$TableNameID$",tableName.Replace("Master","").Replace("Txn","") + "ID");

                                            using (StreamWriter sw = new StreamWriter(pathWithControllerName))
                                            {
                                                sw.Write(newContent);
                                            }
                                        }
                                    }
                                }

                                #endregion Creating Controller.
                             

                                #region Creating View.
                                string viewpath = areaPath + "Views" + "\\" + tableName;

                                if (!Directory.Exists(viewpath))
                                    Directory.CreateDirectory(viewpath);

                                if (Directory.Exists(viewpath))
                                {
                                     
                                    string pathWithIndexViewName = viewpath + "\\" + "Index.cshtml";
                                    FileInfo indexFileInfo = new FileInfo(pathWithIndexViewName);
                                    if (!indexFileInfo.Exists)
                                    {
                                        using (StreamReader streamReader = new StreamReader(rootpath + _indexViewTemplatePath))
                                        {
                                            string fileContent = streamReader.ReadToEnd();

                                            string newContent = fileContent.Replace("$TableName$", tableName).Replace("$ModuleName$", selectedPackage).Replace("$Title$", tableName);

                                            using (StreamWriter sw = new StreamWriter(pathWithIndexViewName))
                                            {
                                                sw.Write(newContent);
                                            }
                                        }
                                    }
                                    

                                    string pathWithAddUpdateViewName = viewpath + "\\" + "AddOrUpdate" + tableName + ".cshtml";
                                    FileInfo addUpdateFileInfo = new FileInfo(pathWithAddUpdateViewName);
                                    if (!addUpdateFileInfo.Exists)
                                    {
                                        using (StreamReader streamReader = new StreamReader(rootpath + _addUpdateViewTemplatePath))
                                        {
                                            string fileContent = streamReader.ReadToEnd();

                                            string GenerateControl = string.Empty;
                                            string GenerateDropdownSelection = string.Empty;
                                            string GenerateDropdownSelectionList = string.Empty;
                                            //GenerateControl = "<div class='row mt-3'><div class='col-12'>";
                                            GenerateControl = "<div class='row mt-3'><div class='col-12'>";

                                            DataTable dataTable1 = _dynamicFormService.GetDataTableStructure(tableName).Result;

                                            using (StreamWriter sw = new StreamWriter(pathWithAddUpdateViewName))
                                            {

                                                foreach (DataRow row in dataTable1.Rows)
                                                {


                                                    if (row["DataType"].ToString().ToLower() == "int" && row["IsForeignKey"].ToString() == "f")
                                                    {
                                                        GenerateControl += "\r\n <div class='row mb-3'>\r\n <label for='' class='col-sm-3 col-form-label'>" + row["columnName"].ToString() + "</label>\r\n <div class='col-sm-9'>\r\n <input type='text' class='form-control' id='" + row["columnName"].ToString() + "' asp-for='" + row["columnName"].ToString() + "' name='" + row["columnName"].ToString() + "'>\r\n <span asp-validation-for='" + row["columnName"].ToString() + "' class='text-danger'>\r\n </span>\r\n </div>\r\n </div>\r\n \r\n ";
                                                    }
                                                    else if (row["DataType"].ToString().ToLower() == "int" && row["IsForeignKey"].ToString() == "t")
                                                    {
                                                        string MethodName = "GetAll" + row["columnName"].ToString().Remove(row["columnName"].ToString().Length - 2, 2) + "Async()";

                                                        GenerateControl += "<div class='row mb-3'>\r\n <label for='' class='col-sm-3 col-form-label'>" + row["columnName"].ToString() + "</label>\r\n <div class='col-sm-9'>\r\n <select class='form-select' asp-for='" + row["columnName"].ToString() + "' id='choices-multiple-remove-button-" + row["columnName"].ToString() + "' asp-items='@CommonExtension." + MethodName + "'>\r\n <option value=''>Select here...</option>\r\n </select>\r\n </div>\r\n </div>";

                                                        //GenerateDropdownSelection += "let " + row["columnName"].ToString() + "s = document.getElementById(choices-multiple-remove-button-" + row["columnName"].ToString() + ").value;\r\n    $.each(" + row["columnName"].ToString() + "s.split('',''), function (i, e) {\r\n    $('#choices-multiple-remove-button-" + row["columnName"].ToString() + " option[value='' + e + '']').prop('selected', true);\r\n   });\r\n \r\n";

                                                        

                                                        GenerateDropdownSelectionList += " var multipleCancelButtonParty = new Choices('#choices-multiple-remove-button-" + row["columnName"].ToString() + "', {\r\n            removeItemButton: false,\r\n            maxItemCount: 10,\r\n            searchResultLimit: 10,\r\n            renderChoiceLimit: 10\r\n        });\r\n \r\n";

                                                        string spName = row["SPName"].ToString();
                                                        if (!spName.IsNotStringNullOrEmpty())
                                                        {
                                                            spName = "Usp_GetAll_"+ tableName + "ForDropdown";
                                                        }
                                                        CommonExtentionMethod(Servicerootpath, row["columnName"].ToString(), spName);

                                                    }




                                                    if (row["DataType"].ToString().ToLower() == "varchar" || row["DataType"].ToString().ToLower() == "money")
                                                    {
                                                        GenerateControl += "\r\n <div class='row mb-3'>\r\n <label for='' class='col-sm-3 col-form-label'>" + row["columnName"].ToString() + "</label>\r\n <div class='col-sm-9'>\r\n <input type='text' class='form-control' id='" + row["columnName"].ToString() + "' asp-for='" + row["columnName"].ToString() + "' name='" + row["columnName"].ToString() + "'>\r\n <span asp-validation-for='" + row["columnName"].ToString() + "' class='text-danger'>\r\n </span>\r\n </div>\r\n </div>\r\n \r\n ";
                                                    }

                                                    if (row["DataType"].ToString().ToLower() == "datetime")
                                                    {
                                                        GenerateControl += "\r\n <div class='row mb-3'>\r\n <label for='' class='col-sm-3 col-form-label'>" + row["columnName"].ToString() + "</label>\r\n <div class='col-sm-9'>\r\n <input type='date' class='form-control' id='" + row["columnName"].ToString() + "' asp-for='" + row["columnName"].ToString() + "' name='" + row["columnName"].ToString() + "'>\r\n <span asp-validation-for='" + row["columnName"].ToString() + "' class='text-danger'>\r\n </span>\r\n </div>\r\n </div>\r\n \r\n ";
                                                    }
                                                    if (row["DataType"].ToString().ToLower() == "bit")
                                                    {
                                                        GenerateControl += "<div class='row mb-3'><label for='' class='col-sm-3 col-form-label'>" + row["columnName"].ToString() + ":</label><div class='col-sm-9'><input type='checkbox' class='form-check-input' role='switch' asp-for='" + row["columnName"].ToString() + "'><span asp-validation-for='" + row["columnName"].ToString() + "' class='text-danger'></span></div></div>";
                                                    }

                                                    //if (row["DataType"].ToString().Equals("MultiLineText"))
                                                    //{
                                                    //    GenerateControl += "<div class='row mb-3'><label for='' class='col-sm-3 col-form-label '>" + row["columnName"].ToString() + ":</label><div class='col-sm-9'><textarea class='form-control' rows='5' cols='50' id='" + row["columnName"].ToString() + "'></textarea></div></div>";
                                                    //}
                                                }

                                                GenerateControl += "</div></div>";

                                                string newContent = fileContent.Replace("$TableName$", tableName).Replace("$ModuleName$", selectedPackage).Replace("$ReplaceController$", GenerateControl).Replace("$DropDownSelection$", GenerateDropdownSelection).Replace("$DropDownSelectionList$", GenerateDropdownSelectionList);

                                                sw.Write(newContent);
                                            }
                                        }
                                    }
                                }

                                #endregion Creating View.

                            }
                        }

                        #endregion Creating Area.

                       

                        #region Dependency Update

                          FileInfo dependencyFileInfo = new FileInfo(Servicerootpath + _dependencyFile);
                        if (dependencyFileInfo.Exists)
                        {
                            string fileContent = string.Empty;
                            using (StreamReader streamReader = new StreamReader(Servicerootpath + _dependencyFile))
                            {
                                fileContent = streamReader.ReadToEnd();
                            }

                            //using Business.Interface.IFruitMasterService;
                            //using Business.Service.STest.FruitMaster;

                            string nameSpaceInterface = "using Business.Interface." + selectedPackage + ".I" + tableName + "";
                            string nameSpaceService = "using Business.Service." + selectedPackage + ".S" + tableName + ";\r\n //$UsingInterFace$;\r\n //$UsingService$;";

                            string dependencyText = "\t services.AddTransient<" + tableName + "Interface, " + tableName + "Service>(); \n\t\t//$InjectForm$";

                            string newContent = fileContent
                                .Replace("//$UsingInterFace$", nameSpaceInterface)
                                .Replace("//$UsingService$;", nameSpaceService)
                                .Replace("//$InjectForm$", dependencyText);

                            using (FileStream fileStream = new FileStream(Servicerootpath + _dependencyFile, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                using (StreamWriter writer = new StreamWriter(fileStream))
                                {
                                    writer.Write(newContent);
                                    writer.Flush();
                                    writer.Close();
                                }
                            }
                        }
                        #endregion Dependency Update

                      
                        return Json(new { status = true, message = MessageHelper.Added });
                    }
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });

                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Add update table.

        //public string makeInputpara(String ModelName)
        //{


        //}
        #region CommonExtention Method Created

        public void CommonExtentionMethod(String Servicerootpath, string ColumnName, string SPName)
        {
            try 
            { 
            ///Common Extension 
            string objectName = ColumnName.Replace("ID", "");
            string nameMethod = "GetAll" + ColumnName.Replace("ID", "") + "Async";

            FileInfo dependencyFileInfo = new FileInfo(Servicerootpath + _commonExtentionFilePath);
            if (dependencyFileInfo.Exists)
            {
                string fileContent = string.Empty;
                using (StreamReader streamReader = new StreamReader(Servicerootpath + _commonExtentionFilePath))
                {
                    fileContent = streamReader.ReadToEnd();
                }

                if (!fileContent.Contains(nameMethod))
                {
                    string methodString = "\r\n \t #region " + nameMethod + " - "+ objectName + " List for dropdown list\r\n\r\n        public static SelectList " + nameMethod + "()\r\n        {\r\n            try\r\n            {\r\n                var "+ objectName + "List = _commonmasterService."+ nameMethod + "().Result;\r\n                return new SelectList(" + objectName + "List, \""+ objectName + "ID\", \"" + objectName + "Name\");\r\n            }\r\n            catch\r\n            {\r\n                return new SelectList(Enumerable.Empty<SelectListItem>());\r\n            }\r\n        }\r\n        #endregion  "+ nameMethod + " -  "+ objectName + " List for dropdown list;\r\n \r\n \t//$AddCommonExtensionMethod$";

                    string newContent = fileContent.Replace("//$AddCommonExtensionMethod$", methodString);


                    using (FileStream fileStreamComExt = new FileStream(Servicerootpath + _commonExtentionFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (StreamWriter swriter = new StreamWriter(fileStreamComExt))
                        {
                            swriter.Write(newContent);
                            swriter.Flush();
                            swriter.Close();
                        }
                    }

                   


                    ///Common Extension service ---------------------------------------------
                    
                    
                    string fileContentservice = string.Empty;
                    using (StreamReader streamReaderComsvr = new StreamReader(Servicerootpath + _commonExtentionServiceFilePath))
                    {
                        fileContentservice = streamReaderComsvr.ReadToEnd();
                    }

                    string objectModelName = ColumnName.Replace("ID", "") + "MasterModelDropdown";
                    string ServicemethodString = "public async Task<PagedDataTable<"+ objectModelName +">> " + nameMethod + "()\r\n        {\r\n            DataTable table = new DataTable();\r\n            int totalItemCount = 0;\r\n            PagedDataTable<"+ objectModelName +"> lst = new PagedDataTable<"+ objectModelName +">();\r\n            try\r\n            {\r\n\r\n                SqlParameter[] sp = new SqlParameter[] { new SqlParameter(\"@SearchString\", null) };\r\n                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, \""+ SPName + "\", sp))\r\n                {\r\n                    if (ds.Tables.Count > 0)\r\n                    {\r\n                        table = ds.Tables[0];\r\n                        if (table.Rows.Count > 0)\r\n                        {\r\n                            if (table.ContainColumn(\"TotalCount\"))\r\n                                totalItemCount = Convert.ToInt32(table.Rows[0][\"TotalCount\"]);\r\n                            else\r\n                                totalItemCount = table.Rows.Count;\r\n                        }\r\n                        lst = table.ToPagedDataTableList<"+ objectModelName + ">(0, 0, totalItemCount);\r\n                    }\r\n                    return lst;\r\n                }\r\n            }\r\n            catch\r\n            {\r\n                throw;\r\n            }\r\n            finally\r\n            {\r\n                if (table != null)\r\n                    table.Dispose();\r\n            }\r\n        }\r\n \t //$AddCommonMasterServiceMethod$";

                    string newContentComSvr = fileContentservice.Replace("//$AddCommonMasterServiceMethod$", ServicemethodString);


                    using (FileStream fileStreamComExt = new FileStream(Servicerootpath + _commonExtentionServiceFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (StreamWriter writerComSvr = new StreamWriter(fileStreamComExt))
                        {
                            writerComSvr.Write(newContentComSvr);
                            writerComSvr.Flush();
                            writerComSvr.Close();
                        }
                    }



                    ///Common Extension interface ---------------------------------------------

 
                    
                    string fileContentinterface = string.Empty;
                    using (StreamReader streamReaderComIsvr = new StreamReader(Servicerootpath + _commonExtentionInterfaceFilePath))
                    {
                        fileContentinterface = streamReaderComIsvr.ReadToEnd();
                    }
                    
                    string InterfacemethodString = "Task<PagedDataTable<" + objectModelName + ">> " + nameMethod + "();\r\n \r\n \t //$AddICommonMasterServiceMethod$";

                    string newContentComISvr = fileContentinterface.Replace("//$AddICommonMasterServiceMethod$", InterfacemethodString);


                    using (FileStream fileStreamComISvr = new FileStream(Servicerootpath + _commonExtentionInterfaceFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (StreamWriter writerComISvr = new StreamWriter(fileStreamComISvr))
                        {
                            writerComISvr.Write(newContentComISvr);
                            writerComISvr.Flush();
                            writerComISvr.Close();
                        }
                    }



                    ///Common Extension Master Model 
                    string fileContentModel = string.Empty;
                    using (StreamReader streamReaderComModel = new StreamReader(Servicerootpath + _commonExtentionModelFilePath))
                    {
                        fileContentModel = streamReaderComModel.ReadToEnd();
                    }

                    string modelmethodString = string.Empty;
                    modelmethodString = "\r\n public class " + objectModelName + "\r\n    {\r\n        public int "+ ColumnName  + " { get; set; }\r\n        public string "+ objectName + "Name { get; set; }\r\n    }\r\n \r\n \t //$AddCommonMasterModel$";

                    string newContentComModel = fileContentModel.Replace("//$AddCommonMasterModel$", modelmethodString);


                    using (FileStream fileStreamComModel = new FileStream(Servicerootpath + _commonExtentionModelFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (StreamWriter writerComModel = new StreamWriter(fileStreamComModel))
                        {
                            writerComModel.Write(newContentComModel);
                            writerComModel.Flush();
                            writerComModel.Close();
                        }
                    }


                }

            }


            }
            catch (Exception ex)
            {
                Json(new { status = false, message = ex.Message });
                throw;
            }
        }

        #endregion  CommonExtention Method Created

    }
}
