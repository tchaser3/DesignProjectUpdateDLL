/* Title:           Design Project Update Class
 * Date:            1-22-19
 * Author:          Terry Holmes
 * 
 * Description:     This is the class that is used for Design Project Updates */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace DesignProjectUpdateDLL
{
    public class DesignProjectUpdateClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        DesignProjectUpdatesDataSet aDesignProjectUpdatesDataSet;
        DesignProjectUpdatesDataSetTableAdapters.designprojectupdatesTableAdapter aDesignProjectUpdatesTableAdapter;

        InsertIntoDesignProjectUpdatesEntryTableAdapters.QueriesTableAdapter aInsertIntoDesignProjectUpdatesTableAdapter;

        FindDesignProjectUpdatesByProjectIDDataSet aFindDesignProjectUpdatesByProjectIDDataSet;
        FindDesignProjectUpdatesByProjectIDDataSetTableAdapters.FindDesignProjectUpdatesByProjectIDTableAdapter aFindDesignProjectUpdatesByProjectIDTableAdapter;

        FindDesignProjectUpdatesByEmployeeIDDataSet aFindDesignProjectUpdatesByEmployeeIDDataSet;
        FindDesignProjectUpdatesByEmployeeIDDataSetTableAdapters.FindDesignProjectUpdatesByEmployeeIDTableAdapter aFindDesignProjectUpdatesByEmployeeIDTableAdapter;

        FindDesignProjectUpdatesByDateRangeDataSet aFindDesignProjectUpdatesByDateRangeDataSet;
        FindDesignProjectUpdatesByDateRangeDataSetTableAdapters.FindDesignProjectUpdatesByDateRangeTableAdapter aFindDesignProjectUpdatesByDateRangeTableAdapter;

        FindDetailedDesignProjectReportByLocationDataSet aFindDetailedDesignProjectReportByLocationDataSet;
        FindDetailedDesignProjectReportByLocationDataSetTableAdapters.FindDetailedDesignProjectReportByLocationTableAdapter aFindDetailedDesignProjectReportByLocationTableAdater;

        public FindDetailedDesignProjectReportByLocationDataSet FindDetailedDesignProjectReportByLocation(DateTime datStartTime, DateTime datEndDate, int intOfficeID)
        {
            try
            {
                aFindDetailedDesignProjectReportByLocationDataSet = new FindDetailedDesignProjectReportByLocationDataSet();
                aFindDetailedDesignProjectReportByLocationTableAdater = new FindDetailedDesignProjectReportByLocationDataSetTableAdapters.FindDetailedDesignProjectReportByLocationTableAdapter();
                aFindDetailedDesignProjectReportByLocationTableAdater.Fill(aFindDetailedDesignProjectReportByLocationDataSet.FindDetailedDesignProjectReportByLocation, datStartTime, datEndDate, intOfficeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Class // Find Detailed Design Project Report By Location " + Ex.Message);
            }

            return aFindDetailedDesignProjectReportByLocationDataSet;
        }
        public FindDesignProjectUpdatesByDateRangeDataSet FindDesignProjectUpdatesByDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindDesignProjectUpdatesByDateRangeDataSet = new FindDesignProjectUpdatesByDateRangeDataSet();
                aFindDesignProjectUpdatesByDateRangeTableAdapter = new FindDesignProjectUpdatesByDateRangeDataSetTableAdapters.FindDesignProjectUpdatesByDateRangeTableAdapter();
                aFindDesignProjectUpdatesByDateRangeTableAdapter.Fill(aFindDesignProjectUpdatesByDateRangeDataSet.FindDesignProjectUpdatesByDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Update Class // Find Design Project Updates By Date Range " + Ex.Message);
            }

            return aFindDesignProjectUpdatesByDateRangeDataSet;
        }
        public FindDesignProjectUpdatesByEmployeeIDDataSet FindDesignProjectUpdatesByEmployeeID(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindDesignProjectUpdatesByEmployeeIDDataSet = new FindDesignProjectUpdatesByEmployeeIDDataSet();
                aFindDesignProjectUpdatesByEmployeeIDTableAdapter = new FindDesignProjectUpdatesByEmployeeIDDataSetTableAdapters.FindDesignProjectUpdatesByEmployeeIDTableAdapter();
                aFindDesignProjectUpdatesByEmployeeIDTableAdapter.Fill(aFindDesignProjectUpdatesByEmployeeIDDataSet.FindDesignProjectUpdatesByEmployeeID, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Updates Class // Find Design Project Updates By Employee ID " + Ex.Message);
            }

            return aFindDesignProjectUpdatesByEmployeeIDDataSet;
        }
        public FindDesignProjectUpdatesByProjectIDDataSet FindDesignProjectUpdatesByProjectID(int intProjectID)
        {
            try
            {
                aFindDesignProjectUpdatesByProjectIDDataSet = new FindDesignProjectUpdatesByProjectIDDataSet();
                aFindDesignProjectUpdatesByProjectIDTableAdapter = new FindDesignProjectUpdatesByProjectIDDataSetTableAdapters.FindDesignProjectUpdatesByProjectIDTableAdapter();
                aFindDesignProjectUpdatesByProjectIDTableAdapter.Fill(aFindDesignProjectUpdatesByProjectIDDataSet.FindDesignProjectUpdatesByProjectID, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Update Class // Find Design Project Updates By Project ID " + Ex.Message);
            }

            return aFindDesignProjectUpdatesByProjectIDDataSet;
        }
        public bool InsertIntoDesigProjectUpdates(int intProjectID, int intEmployeeID, string strProjectUpdate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertIntoDesignProjectUpdatesTableAdapter = new InsertIntoDesignProjectUpdatesEntryTableAdapters.QueriesTableAdapter();
                aInsertIntoDesignProjectUpdatesTableAdapter.InsertIntoDesignProjectUpdates(intProjectID, intEmployeeID, DateTime.Now, strProjectUpdate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Updates Class // Insert Into Design Project Updates " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public DesignProjectUpdatesDataSet GetDesignProjectUpdatesInfo()
        {
            try
            {
                aDesignProjectUpdatesDataSet = new DesignProjectUpdatesDataSet();
                aDesignProjectUpdatesTableAdapter = new DesignProjectUpdatesDataSetTableAdapters.designprojectupdatesTableAdapter();
                aDesignProjectUpdatesTableAdapter.Fill(aDesignProjectUpdatesDataSet.designprojectupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Projects Update Class // Get Design Project Updates Info " + Ex.Message);
            }

            return aDesignProjectUpdatesDataSet;
        }
        public void UpdateDesignProjectsUpdateDB(DesignProjectUpdatesDataSet aDesignProjectUpdatesDataSet)
        {
            try
            {
                aDesignProjectUpdatesTableAdapter = new DesignProjectUpdatesDataSetTableAdapters.designprojectupdatesTableAdapter();
                aDesignProjectUpdatesTableAdapter.Update(aDesignProjectUpdatesDataSet.designprojectupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Projects Update Class // Update Design Project Updates DB " + Ex.Message);
            }
        }
    }
}
