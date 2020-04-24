using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem.ViewModels.Enums
{
    /// <summary>
    /// 民族
    /// </summary>
    public enum EnumNation
    {
        /// <summary>
        /// 汉族
        /// </summary>
        [Display(Name = "汉族")]
        hanzu,
        /// <summary>
        /// 蒙古族
        /// </summary>
        [Display(Name = "蒙古族")]
        mengguzu,
        /// <summary>
        /// 回族
        /// </summary>
        [Display(Name = "回族")]
        huizu,
        /// <summary>
        /// 藏族
        /// </summary>
        [Display(Name = "藏族")]
        zangzu,
        /// <summary>
        /// 维吾尔族
        /// </summary>
        [Display(Name = "维吾尔族")]
        weiwuerzu,
        /// <summary>
        /// 苗族
        /// </summary>
        [Display(Name = "苗族")]
        miaozu,
        /// <summary>
        /// 彝族
        /// </summary>
        [Display(Name = "彝族")]
        yizu,
        /// <summary>
        /// 壮族
        /// </summary>
        [Display(Name = "壮族")]
        zhuangzu,
        /// <summary>
        /// 布依族
        /// </summary>
        [Display(Name = "布依族")]
        buyizu,
        /// <summary>
        /// 朝鲜族
        /// </summary>
        [Display(Name = "朝鲜族")]
        chaoxianzu,
        /// <summary>
        /// 满族
        /// </summary>
        [Display(Name = "满族")]
        manzu,
        /// <summary>
        /// 侗族
        /// </summary>
        [Display(Name = "侗族")]
        dongzu,
        /// <summary>
        /// 瑶族
        /// </summary>
        [Display(Name = "瑶族")]
        yaozu,
        /// <summary>
        /// 白族
        /// </summary>
        [Display(Name = "白族")]
        baizu,
        /// <summary>
        /// 土家族
        /// </summary>
        [Display(Name = "土家族")]
        tujiazu,
        /// <summary>
        /// 哈尼族
        /// </summary>
        [Display(Name = "哈尼族")]
        hanizu,
        /// <summary>
        /// 哈萨克族
        /// </summary>
        [Display(Name = "哈萨克族")]
        hasakezu,
        /// <summary>
        /// 傣族
        /// </summary>
        [Display(Name = "傣族")]
        daizu,
        /// <summary>
        /// 黎族
        /// </summary>
        [Display(Name = "黎族")]
        lizu,
        /// <summary>
        /// 僳僳族
        /// </summary>
        [Display(Name = "僳僳族")]
        susuzu,
        /// <summary>
        /// 佤族
        /// </summary>
        [Display(Name = "佤族")]
        wazu,
        /// <summary>
        /// 畲族
        /// </summary>
        [Display(Name = "畲族")]
        shezu,
        /// <summary>
        /// 高山族
        /// </summary>
        [Display(Name = "高山族")]
        gaoshanzu,
        /// <summary>
        /// 拉祜族
        /// </summary>
        [Display(Name = "拉祜族")]
        lahuzu,
        /// <summary>
        /// 水族
        /// </summary>
        [Display(Name = "水族")]
        shuizu,
        /// <summary>
        /// 东乡族
        /// </summary>
        [Display(Name = "东乡族")]
        dongxiangzu,
        /// <summary>
        /// 纳西族
        /// </summary>
        [Display(Name = "纳西族")]
        naxizu,
        /// <summary>
        /// 景颇族
        /// </summary>
        [Display(Name = "景颇族")]
        jingpozu,
        /// <summary>
        /// 柯尔克孜族
        /// </summary>
        [Display(Name = "柯尔克孜族")]
        keerkezizu,
        /// <summary>
        /// 土族
        /// </summary>
        [Display(Name = "土族")]
        tuzu,
        /// <summary>
        /// 达斡尔族
        /// </summary>
        [Display(Name = "达斡尔族")]
        dawoerzu,
        /// <summary>
        /// 仫佬族
        /// </summary>
        [Display(Name = "仫佬族")]
        molaozu,
        /// <summary>
        /// 羌族
        /// </summary>
        [Display(Name = "羌族")]
        qiangzu,
        /// <summary>
        /// 布朗族
        /// </summary>
        [Display(Name = "布朗族")]
        bulangzu,
        /// <summary>
        /// 撒拉族
        /// </summary>
        [Display(Name = "撒拉族")]
        salazu,
        /// <summary>
        /// 毛南族
        /// </summary>
        [Display(Name = "毛南族")]
        maonanzu,
        /// <summary>
        /// 仡佬族
        /// </summary>
        [Display(Name = "仡佬族")]
        yilaozu,
        /// <summary>
        /// 锡伯族
        /// </summary>
        [Display(Name = "锡伯族")]
        xibozu,
        /// <summary>
        /// 阿昌族
        /// </summary>
        [Display(Name = "阿昌族")]
        achangzu,
        /// <summary>
        /// 普米族
        /// </summary>
        [Display(Name = "普米族")]
        pumizu,
        /// <summary>
        /// 塔吉克族
        /// </summary>
        [Display(Name = "塔吉克族")]
        tajikezu,
        /// <summary>
        /// 怒族
        /// </summary>
        [Display(Name = "怒族")]
        nuzu,
        /// <summary>
        /// 乌孜别克族
        /// </summary>
        [Display(Name = "乌孜别克族")]
        wuzibiekezu,
        /// <summary>
        /// 俄罗斯族
        /// </summary>
        [Display(Name = "俄罗斯族")]
        eluosizu,
        /// <summary>
        /// 鄂温克族
        /// </summary>
        [Display(Name = "鄂温克族")]
        ewenkezu,
        /// <summary>
        /// 德昂族
        /// </summary>
        [Display(Name = "德昂族")]
        deangzu,
        /// <summary>
        /// 保安族
        /// </summary>
        [Display(Name = "保安族")]
        baoanzu,
        /// <summary>
        /// 裕固族
        /// </summary>
        [Display(Name = "裕固族")]
        yuguzu,
        /// <summary>
        /// 京族
        /// </summary>
        [Display(Name = "京族")]
        jingzu,
        /// <summary>
        /// 塔塔尔族
        /// </summary>
        [Display(Name = "塔塔尔族")]
        tataerzu,
        /// <summary>
        /// 独龙族
        /// </summary>
        [Display(Name = "独龙族")]
        dulongzu,
        /// <summary>
        /// 鄂伦春族
        /// </summary>
        [Display(Name = "鄂伦春族")]
        elunchunzu,
        /// <summary>
        /// 赫哲族
        /// </summary>
        [Display(Name = "赫哲族")]
        hezhezu,
        /// <summary>
        /// 门巴族
        /// </summary>
        [Display(Name = "门巴族")]
        menbazu,
        /// <summary>
        /// 珞巴族
        /// </summary>
        [Display(Name = "珞巴族")]
        luobazu,
        /// <summary>
        /// 基诺族
        /// </summary>
        [Display(Name = "基诺族")]
        jinuozu
    }
}
