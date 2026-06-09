using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permit_to_work.Migrations
{
    /// <inheritdoc />
    public partial class LoginTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ApprovalStructures",
            //    columns: table => new
            //    {
            //        ApprovalId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ContractorTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NoOfWorkmen = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
            //        WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RiskFallHeight = table.Column<bool>(type: "bit", nullable: false),
            //        RiskWeather = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFlying = table.Column<bool>(type: "bit", nullable: false),
            //        PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
            //        PPEShoes = table.Column<bool>(type: "bit", nullable: false),
            //        PPEGloves = table.Column<bool>(type: "bit", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApprovalStructures", x => x.ApprovalId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ApproverMasters",
            //    columns: table => new
            //    {
            //        ApproverId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ApproverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ApproverEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UnitId = table.Column<int>(type: "int", nullable: false),
            //        DepartmentId = table.Column<int>(type: "int", nullable: false),
            //        LevelIIApprover = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LevelIIIApprover = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApproverMasters", x => x.ApproverId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Role = table.Column<int>(type: "int", nullable: false),
            //        Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ColdWorkPermits",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ContractorTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NoOfWorkmen = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RiskFallHeight = table.Column<bool>(type: "bit", nullable: false),
            //        RiskWeather = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFlying = table.Column<bool>(type: "bit", nullable: false),
            //        Equipment = table.Column<bool>(type: "bit", nullable: false),
            //        Falling = table.Column<bool>(type: "bit", nullable: false),
            //        Protruding = table.Column<bool>(type: "bit", nullable: false),
            //        Tripping = table.Column<bool>(type: "bit", nullable: false),
            //        Faulty = table.Column<bool>(type: "bit", nullable: false),
            //        Noise = table.Column<bool>(type: "bit", nullable: false),
            //        Heat = table.Column<bool>(type: "bit", nullable: false),
            //        Vibration = table.Column<bool>(type: "bit", nullable: false),
            //        Illumination = table.Column<bool>(type: "bit", nullable: false),
            //        PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
            //        PPEShoes = table.Column<bool>(type: "bit", nullable: false),
            //        PPEGloves = table.Column<bool>(type: "bit", nullable: false),
            //        InsuranceAvailable = table.Column<bool>(type: "bit", nullable: false),
            //        WC = table.Column<bool>(type: "bit", nullable: false),
            //        ESI = table.Column<bool>(type: "bit", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IssuerDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SuspensionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ColdWorkPermits", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DepartmentMasters",
            //    columns: table => new
            //    {
            //        DepartmentId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DepartmentMasters", x => x.DepartmentId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ElectricalIsolationPermits",
            //    columns: table => new
            //    {
            //        PermitId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PermitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NumberOfWorkmen = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EnergizedEquipment = table.Column<bool>(type: "bit", nullable: false),
            //        DeEnergizedEquipment = table.Column<bool>(type: "bit", nullable: false),
            //        WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RiskElectrocution = table.Column<bool>(type: "bit", nullable: false),
            //        RiskArcFlash = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFlyingParticles = table.Column<bool>(type: "bit", nullable: false),
            //        RiskNoise = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFallingObjects = table.Column<bool>(type: "bit", nullable: false),
            //        RiskProtrudingParts = table.Column<bool>(type: "bit", nullable: false),
            //        RiskTripping = table.Column<bool>(type: "bit", nullable: false),
            //        RiskElectricShock = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFire = table.Column<bool>(type: "bit", nullable: false),
            //        RiskManualHandling = table.Column<bool>(type: "bit", nullable: false),
            //        RiskElectricBurn = table.Column<bool>(type: "bit", nullable: false),
            //        RiskOverheadLines = table.Column<bool>(type: "bit", nullable: false),
            //        OtherRisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        JSA = table.Column<bool>(type: "bit", nullable: false),
            //        RiskAssessment = table.Column<bool>(type: "bit", nullable: false),
            //        OtherDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Precaution = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SafeDistance = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Voltage = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Distance = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ConfinedSpace = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ElectricalIsolation = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SwitchOut = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutTagout = table.Column<bool>(type: "bit", nullable: false),
            //        NumberOfLocks = table.Column<int>(type: "int", nullable: false),
            //        TestConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        ToolsTested = table.Column<bool>(type: "bit", nullable: false),
            //        OtherLOTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WC = table.Column<bool>(type: "bit", nullable: false),
            //        ESI = table.Column<bool>(type: "bit", nullable: false),
            //        OtherInsurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FireExtinguisher = table.Column<bool>(type: "bit", nullable: false),
            //        FireExtinguisherType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FireExtinguisherQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FireExtinguisherSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AccessRoute = table.Column<bool>(type: "bit", nullable: false),
            //        DangerSign = table.Column<bool>(type: "bit", nullable: false),
            //        Lighting = table.Column<bool>(type: "bit", nullable: false),
            //        SafetyBarriers = table.Column<bool>(type: "bit", nullable: false),
            //        PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
            //        PPEShoes = table.Column<bool>(type: "bit", nullable: false),
            //        PPEElectricalGloves = table.Column<bool>(type: "bit", nullable: false),
            //        PPEHalfMask = table.Column<bool>(type: "bit", nullable: false),
            //        PPEFaceShield = table.Column<bool>(type: "bit", nullable: false),
            //        PPEArcFlash = table.Column<bool>(type: "bit", nullable: false),
            //        PPEDustMask = table.Column<bool>(type: "bit", nullable: false),
            //        PPEEarPlug = table.Column<bool>(type: "bit", nullable: false),
            //        PPESafetyGoggles = table.Column<bool>(type: "bit", nullable: false),
            //        PPEReflectiveVest = table.Column<bool>(type: "bit", nullable: false),
            //        PPESafetyEar = table.Column<bool>(type: "bit", nullable: false),
            //        OtherPPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverSignatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IssuerSignatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SuspensionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SuspensionSignatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ElectricalIsolationPermits", x => x.PermitId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HotWorkPermits",
            //    columns: table => new
            //    {
            //        PermitId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NoOfWorkmen = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Welding = table.Column<bool>(type: "bit", nullable: false),
            //        ChippingCuttingGrinding = table.Column<bool>(type: "bit", nullable: false),
            //        WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AttachJSA = table.Column<bool>(type: "bit", nullable: false),
            //        AttachRiskAssessment = table.Column<bool>(type: "bit", nullable: false),
            //        AttachOther = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Precaution = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsWelderCertified = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CombustibleRemoved = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        HosesFreeGrease = table.Column<bool>(type: "bit", nullable: false),
            //        HosesCutCrack = table.Column<bool>(type: "bit", nullable: false),
            //        HosesSpecialClips = table.Column<bool>(type: "bit", nullable: false),
            //        HosesNA = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Regulator = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RegulatorNA = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FlashbackArrestors = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CylindersProvided = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EmergencyTeamAvailable = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EmergencyContact1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EmergencyContact2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EmergencyContact3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ToolsTested = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WC = table.Column<bool>(type: "bit", nullable: false),
            //        ESI = table.Column<bool>(type: "bit", nullable: false),
            //        WCFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ESIFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FireExtinguisherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FireExtinguisherChecked = table.Column<bool>(type: "bit", nullable: false),
            //        FireBlanketChecked = table.Column<bool>(type: "bit", nullable: false),
            //        WarningSignChecked = table.Column<bool>(type: "bit", nullable: false),
            //        LightingChecked = table.Column<bool>(type: "bit", nullable: false),
            //        SafetyBarriersChecked = table.Column<bool>(type: "bit", nullable: false),
            //        SandBucketChecked = table.Column<bool>(type: "bit", nullable: false),
            //        Helmet = table.Column<bool>(type: "bit", nullable: false),
            //        SafetyShoes = table.Column<bool>(type: "bit", nullable: false),
            //        WeldingGloves = table.Column<bool>(type: "bit", nullable: false),
            //        FaceShield = table.Column<bool>(type: "bit", nullable: false),
            //        WeldingGoggles = table.Column<bool>(type: "bit", nullable: false),
            //        Apron = table.Column<bool>(type: "bit", nullable: false),
            //        GasMask = table.Column<bool>(type: "bit", nullable: false),
            //        EarPlugs = table.Column<bool>(type: "bit", nullable: false),
            //        WeldingShield = table.Column<bool>(type: "bit", nullable: false),
            //        WeldingClothes = table.Column<bool>(type: "bit", nullable: false),
            //        OtherPPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IssuerDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SuspensionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SuspensionSignatureDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HotWorkPermits", x => x.PermitId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LiftingOperationPermits",
            //    columns: table => new
            //    {
            //        PermitId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NoOfWorkmen = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ExpectedCompletionTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        TruckMounted = table.Column<bool>(type: "bit", nullable: false),
            //        HydraCrane = table.Column<bool>(type: "bit", nullable: false),
            //        OverheadCrane = table.Column<bool>(type: "bit", nullable: false),
            //        LoadWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LoadDimension = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LoadQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Toppling = table.Column<bool>(type: "bit", nullable: false),
            //        FallingObjects = table.Column<bool>(type: "bit", nullable: false),
            //        Overload = table.Column<bool>(type: "bit", nullable: false),
            //        AdverseWeather = table.Column<bool>(type: "bit", nullable: false),
            //        OtherRisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Helmet = table.Column<bool>(type: "bit", nullable: false),
            //        SafetyShoes = table.Column<bool>(type: "bit", nullable: false),
            //        ReflectiveVest = table.Column<bool>(type: "bit", nullable: false),
            //        WC = table.Column<bool>(type: "bit", nullable: false),
            //        ESI = table.Column<bool>(type: "bit", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IssuerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SuspensionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SuspensionSignatureDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LiftingOperationPermits", x => x.PermitId);
            //    });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    loginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.loginId);
                });

            //migrationBuilder.CreateTable(
            //    name: "PermitTypeMasters",
            //    columns: table => new
            //    {
            //        PermitTypeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PermitTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PermitTypeMasters", x => x.PermitTypeId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UnitMasters",
            //    columns: table => new
            //    {
            //        UnitId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UnitMasters", x => x.UnitId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "WorkAtHeightPermits",
            //    columns: table => new
            //    {
            //        PermitId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ContractorTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NoOfWorkmen = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Scaffolding = table.Column<bool>(type: "bit", nullable: false),
            //        Ladder = table.Column<bool>(type: "bit", nullable: false),
            //        AerialLift = table.Column<bool>(type: "bit", nullable: false),
            //        RoofWork = table.Column<bool>(type: "bit", nullable: false),
            //        OtherWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Precaution = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Riskcontrol = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RiskFallHeight = table.Column<bool>(type: "bit", nullable: false),
            //        RiskWeather = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFlyingParticles = table.Column<bool>(type: "bit", nullable: false),
            //        RiskMovingVehicle = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFallingObjects = table.Column<bool>(type: "bit", nullable: false),
            //        RiskProtrudingParts = table.Column<bool>(type: "bit", nullable: false),
            //        RiskTripping = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFaultyEquipment = table.Column<bool>(type: "bit", nullable: false),
            //        RiskFragileSurface = table.Column<bool>(type: "bit", nullable: false),
            //        RiskWorkingBelow = table.Column<bool>(type: "bit", nullable: false),
            //        RiskNearOverheadLines = table.Column<bool>(type: "bit", nullable: false),
            //        RiskNonEnergizedEquipment = table.Column<bool>(type: "bit", nullable: false),
            //        RiskControlImplemented = table.Column<bool>(type: "bit", nullable: false),
            //        GuardRailsSystem = table.Column<bool>(type: "bit", nullable: false),
            //        SafetyNet = table.Column<bool>(type: "bit", nullable: false),
            //        ToeBoard = table.Column<bool>(type: "bit", nullable: false),
            //        LifeLine = table.Column<bool>(type: "bit", nullable: false),
            //        RetractableHarness = table.Column<bool>(type: "bit", nullable: false),
            //        HarnessShockAbsorber = table.Column<bool>(type: "bit", nullable: false),
            //        AccessProvided = table.Column<bool>(type: "bit", nullable: false),
            //        WindGreater32 = table.Column<bool>(type: "bit", nullable: false),
            //        FloorOpeningsCovered = table.Column<bool>(type: "bit", nullable: false),
            //        ScaffoldCertified = table.Column<bool>(type: "bit", nullable: false),
            //        OtherRiskControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DangerWarningSign = table.Column<bool>(type: "bit", nullable: false),
            //        ScaffoldTagSystem = table.Column<bool>(type: "bit", nullable: false),
            //        Lighting = table.Column<bool>(type: "bit", nullable: false),
            //        SafetyBarriers = table.Column<bool>(type: "bit", nullable: false),
            //        BuddySystem = table.Column<bool>(type: "bit", nullable: false),
            //        Rescue = table.Column<bool>(type: "bit", nullable: false),
            //        MaterialBasket = table.Column<bool>(type: "bit", nullable: false),
            //        OtherInspection = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
            //        PPEHelmetChinStrap = table.Column<bool>(type: "bit", nullable: false),
            //        PPEShoes = table.Column<bool>(type: "bit", nullable: false),
            //        PPEGloves = table.Column<bool>(type: "bit", nullable: false),
            //        PPEEarPlug = table.Column<bool>(type: "bit", nullable: false),
            //        PPEReflectiveVest = table.Column<bool>(type: "bit", nullable: false),
            //        PPEDustMask = table.Column<bool>(type: "bit", nullable: false),
            //        PPESafetyClothes = table.Column<bool>(type: "bit", nullable: false),
            //        FallProtection = table.Column<bool>(type: "bit", nullable: false),
            //        GuardRail = table.Column<bool>(type: "bit", nullable: false),
            //        HarnessDoubleHook = table.Column<bool>(type: "bit", nullable: false),
            //        WC = table.Column<bool>(type: "bit", nullable: false),
            //        ESI = table.Column<bool>(type: "bit", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IssuerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SuspensionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SuspensionSignatureDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_WorkAtHeightPermits", x => x.PermitId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PermitMasters",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PermitNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PermitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedByUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedById = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PermitMasters", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PermitMasters_AppUsers_CreatedById",
            //            column: x => x.CreatedById,
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_PermitMasters_CreatedById",
            //    table: "PermitMasters",
            //    column: "CreatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ApprovalStructures");

            //migrationBuilder.DropTable(
            //    name: "ApproverMasters");

            //migrationBuilder.DropTable(
            //    name: "ColdWorkPermits");

            //migrationBuilder.DropTable(
            //    name: "DepartmentMasters");

            //migrationBuilder.DropTable(
            //    name: "ElectricalIsolationPermits");

            //migrationBuilder.DropTable(
            //    name: "HotWorkPermits");

            //migrationBuilder.DropTable(
            //    name: "LiftingOperationPermits");

            migrationBuilder.DropTable(
                name: "Logins");

            //migrationBuilder.DropTable(
            //    name: "PermitMasters");

            //migrationBuilder.DropTable(
            //    name: "PermitTypeMasters");

            //migrationBuilder.DropTable(
            //    name: "UnitMasters");

            //migrationBuilder.DropTable(
            //    name: "WorkAtHeightPermits");

            //migrationBuilder.DropTable(
            //    name: "AppUsers");
        }
    }
}
