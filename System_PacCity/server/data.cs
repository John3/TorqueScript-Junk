//PacCity 6 
//Data Storage System
//--------------------

$pacdp = "config/server/PacCity/data/";

function PacCity_SaveData(%client)
{

    %dataPoint = new FileObject();
    %dataPoint.openForWrite($pacdp @ %client.bl_id @ ".txt");
    %dataPoint.writeLine(%client.name SPC %client.energy SPC %client.handmoney SPC %client.bankmoney SPC %client.demerits SPC %client.tax SPC %client.nextSalary SPC %client.age SPC %client.foodSellPermit SPC %client.gunSellPermit SPC %client.drivePermit SPC %client.gunUsePermit SPC %client.medicalPermit SPC %client.skillMine SPC %client.skillLumber SPC %client.skillPolicing SPC %client.skillManufacturing SPC %client.skillPolitics SPC %client.skillComputer SPC %client.criminalRecord SPC %client.inJail SPC %client.debt SPC %client.jailTime SPC %client.inHospital SPC %client.hospitalTime);
    //write all of those variables...
    echo("PacCity SAVE " @ %client.bl_id);
    %dataPoint.close();
    %dataPoint.delete();
}

function PacCity_LoadData(%client)
{
    %client.bottomPrint("<color:00ff00><font:impact:30>PacCity is loading your data...", 2);
    %dataPoint = new FileObject();
    %dataPoint.openForRead($pacdp @ %client.bl_id @ ".txt");
    %line = %dataPoint.readLine();
    //----------------------------------------------------------------------------no i will not assign a client its name so don't bother doing thatafsdfd
    %client.energy = getWord(%line, 1);
    %client.handmoney = getWord(%line, 2);
    %client.bankmoney = getWord(%line, 3);
    %client.demerits = getWord(%line, 4);
    %client.tax = getWord(%line, 5);
    %client.nextSalary = getWord(%line, 6);
    %client.age = getWord(%line, 7);
    %client.foodSellPermit = getWord(%line, 8);
    %client.gunSellPermit = getWord(%line, 9);
    %client.drivePermit = getWord(%line, 10);
    %client.gunUsePermit = getWord(%line, 11);
    %client.medicalPermit = getWord(%line, 12);
    %client.skillMine = getWord(%line, 13);
    %client.skillLumber = getWord(%line, 14);  
    %client.skillPolicing = getWord(%line, 15);
    %client.skillManufacturing = getWord(%line, 16);
    %client.skillPolitics = getWord(%line, 17);
    %client.skillComputer = getWord(%line, 18);
    %client.criminalRecord = getWord(%line, 19);
    %client.inJail = getWord(%line, 20);
    %client.debt = getWord(%line, 21);
    %client.jailTime = getWord(%line, 22);
    %client.inHospital = getWord(%line, 23);
    %client.hospitalTime = getWord(%line, 24);
    //----------------------------------------------------------------------------
    echo("PacCity LOAD " @ %client.bl_id);
    %dataPoint.close();
    %dataPoint.delete();
    
}


//yeah this code file only has two functions sorry
