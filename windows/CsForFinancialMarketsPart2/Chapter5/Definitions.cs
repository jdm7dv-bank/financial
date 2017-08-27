using System;
using System.Collections.Generic;
using System.Text;

//Author Andrea Germani
    //Payment Frequency
    public enum Freq
    {
        Once = 0,
        Annual = 1,           
        SemiAnnual = 2,
        Quarterly = 4,
        Monthly = 12,         
        Weekly = 52,          
        Daily = 365         
    };

    //DayCount
    public enum Dc 
    {
        //sono quelli di bbl
        _30_360 =1,
        _Act_360 =2, 
        _Act_Act_ISMA,
        _ItalianBTP,
        _Act_365,
        _30_Act,
        _30_365
    }


    

    //Rule used in schedule generation
    public enum Rule 
    {
        Backward,
        Forward
        //bbl Fwd end of month e bwd end of month to be added
    }

    
    //Pay and receive
    public enum PayRec 
    {
        Pay,
        Rec
    }

    //Busines Day Convection //From QL and  Bloomberg
    public enum BusinessDayAdjustment
    {
        // ISDA
        Following,          /*!< Choose the first business day after
                                 the given holiday. */
        ModifiedFollowing,  /*!< Choose the first business day after
                                 the given holiday unless it belongs
                                 to a different month, in which case
                                 choose the first business day before
                                 the holiday. */
        Preceding,          /*!< Choose the first business day before
                                 the given holiday. */
        // NON ISDA
        //ModifiedPreceding,  /*!< Choose the first business day before
        //                         the given holiday unless it belongs
        //                         to a different month, in which case
        //                         choose the first business day after
        //                         the holiday. */
        Unadjusted         /*!< Do not adjust. */
    };

    //Type of tenor
    public enum TenorType
    {        
        D = 365,        
        W = 52,       
        M = 12,       
        Y =1
    };

    //Currency
    public enum Currency { EUR, USD, JPY, AUD, CAD }

    //Fix Float
    public enum FixFloat 
    { 
        //RecFixed, 
        //RecFloating,
        //PayFixed,
        //PayFloating
        Fixed,
        Floating
    }
    
    //Compounding
    public enum Compounding 
    {
        Simple,
        Continuous,
        Compounded    
    }
    
    //Roll Convenction
    public enum RollConvention 
    {
        Forward =1,
        Backward=2,
        //su bbl c'è anche Fwd end of month e bwd end of month
    }

    //EligibleBuildingBlock
    public enum BuildingBlockType 
    {
        EURZERORATE, //zero rate
        EURDEPO ,    //eur deposit
        EURSWAP6M ,  // eurswap vs 6m    
        EURSWAP3M,  // eurswap vs 3m 
        EURBASIS6M3M, // basis swap 6m vs 3m
        EONIASWAP    //eonia swap
    }

    //method of different way of bootrapping
    //Interpolation Methods for Curve Construction PATRICK S. HAGAN & GRAEME WEST Applied Mathematical Finance,Vol. 13, No. 2, 89–129, June 2006
    public enum BootstrapMethod 
    {
        Integrated, //interpolation and bostrapping at same time using minimization 
        Sequential  //first interpolate then bootstrap
    }

    //type of linear interpolation
    public enum OneDimensionInterpolation 
    {
        CubicSplineSecondDeriv,
        Exponential,
        Linear,
        LogLinear
    }

    //Struc for period
    [Serializable]
    public struct Period 
    {
        //Data member 
        public int tenor; // tenor as int (i.e. 1, 2....)
        public TenorType tenorType; // tenor type

        //Constructors
        public Period(int tenor, TenorType tenorType)
        {
            this.tenor = tenor;
            this.tenorType = tenorType;
        }
        public Period(string period) 
        {
            char maturity = period[period.Length - 1];
            int n_periods = int.Parse(period.Remove(period.Length - 1, 1));
            tenor = n_periods;
            //C# 3.0 Cookbook, par 20.10
            tenorType = (TenorType)Enum.Parse(typeof(TenorType), Convert.ToString(maturity).ToUpper());
            
        }

        //Method get string format
        public string GetPeriodStringFormat()
        {
            return tenor + (tenorType.ToString()).ToLower();
        }

    }




    