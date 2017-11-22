using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{

    //**********************************************************************************************************************
    //
    // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
    //
    //! @fn     :
    //
    //! @author :   Grace.Lee
    //
    //! @date   :   2017.07.06
    //
    //! @brief  :
    //
    //! @param  :
    //
    //! @return :   NONE
    //
    //**********************************************************************************************************************
    public interface IScope
    {
        void Connect(TYPE eScopeType);
        void Disconnect();
        void Init();
        double RMS_Get(uint uiChannel);
    }
    //**********************************************************************************************************************
    //
    // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
    //
    //! @fn     :
    //
    //! @author :   Grace.Lee
    //
    //! @date   :   2017.07.06
    //
    //! @brief  :
    //
    //! @param  :
    //
    //! @return :   NONE
    //
    //**********************************************************************************************************************
    public enum TYPE
        {
            NONE,
            KEYSIGHT_2024A,
            KEYSIGHT_4024A,
            LECROY,
        }
}
